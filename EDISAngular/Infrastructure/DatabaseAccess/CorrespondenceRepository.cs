using EDIS_DOMAIN;
using EDIS_DOMAIN.Enum.Enums;
using EDISAngular.Infrastructure.DbFirst;
using EDISAngular.Models.BindingModels;
using EDISAngular.Models.ViewModels;
using EDISAngular.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EDISAngular.Infrastructure.DatabaseAccess
{
    public class CorrespondenceRepository
    {
        private edisDbEntities db;
        public CorrespondenceRepository()
        {
            db = new edisDbEntities();
        }
        public CorrespondenceRepository(edisDbEntities database)
        {
            db = database;
        }

        public void SaveResourceFile(string resourceToken, HttpPostedFile postedFile)
        {
            var extension = System.IO.Path.GetExtension(postedFile.FileName);
            var fileName = BusinessLayerParameters.UserDocumentFolderPrefix + Guid.NewGuid().ToString() + extension;
            var filePath = HttpContext.Current.Server.MapPath(fileName);
            postedFile.SaveAs(filePath);
            var resource = db.ResourcesReferences.FirstOrDefault(s => s.tokenValue == resourceToken);
            if (resource != null)
            {
                resource.fileExtension = extension;
                resource.resourceUrl = fileName;
                db.SaveChanges();
            }
        }
        public string CreateNewMessageToken(string userId)
        {
            ResourcesReference resource = new ResourcesReference()
            {
                resourceUrl = "",
                tokenValue = Guid.NewGuid().ToString(),
                UserId = userId
            };
            db.ResourcesReferences.Add(resource);
            db.SaveChanges();

            return resource.tokenValue;
        }
        public async Task RemoveResourceFile(string resourceToken)
        {
            var resource = db.ResourcesReferences.FirstOrDefault(r => r.tokenValue == resourceToken);
            if (resource != null)
            {
                if (!string.IsNullOrEmpty(resource.resourceUrl))
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(resource.resourceUrl)))
                    {
                        File.Delete(HttpContext.Current.Server.MapPath(resource.resourceUrl));
                    }
                }
                resource.resourceUrl = "";
                await db.SaveChangesAsync();
            }
        }
        public async Task CreateNewMessage(CorrespondenceNoteBindingModel message, int senderRole)
        {
            var resource = db.ResourcesReferences.SingleOrDefault(r => r.tokenValue == message.resourceToken);
            Note note = new Note()
            {
                AccountID = "",
                AdviserID = message.adviserNumber,
                AssetTypeID = message.assetTypeId,
                Body = message.body,
                ClientID = message.clientId,
                DateCompleted = message.dateCompleted,
                DateCreated = DateTime.Now,
                DateDue = message.dateDue,
                DateModified = DateTime.Now,
                FollowupActions = message.followupActions,
                FollowupDate = message.followupDate,
                IsAccepted = message.isAccepted,
                IsDeclined = message.isDeclined,
                NoteType = message.noteTypeId.Value,
                NoteID = Guid.NewGuid().ToString(),
                Subject = message.subject,
                SenderRole = senderRole
            };
            db.Notes.Add(note);
            if (!string.IsNullOrEmpty(resource.resourceUrl))
            {
                Attachment attachment = new Attachment()
                {
                    AttachmentID = Guid.NewGuid().ToString(),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    NoteID = note.NoteID,
                    Path = resource.resourceUrl,
                    Title = note.Subject,
                    AttachmentType = resource.fileExtension
                };
                db.Attachments.Add(attachment);
            }

            await db.SaveChangesAsync();
        }
        public async Task CreateMessageFollowup(CorrespondenceFollowupBindingModel model, int senderRole)
        {
            var correspondingNote = db.Notes.SingleOrDefault(n => n.NoteID == model.existingNoteId);
            Note note = new Note()
            {
                NoteID = Guid.NewGuid().ToString(),
                AdviserID = correspondingNote.AdviserID,
                AccountID = correspondingNote.AccountID,
                AssetClass = correspondingNote.AssetClass,
                AssetTypeID = correspondingNote.AssetTypeID,
                Body = model.body,
                ClientID = correspondingNote.ClientID,
                DateCompleted = correspondingNote.DateCompleted,
                DateCreated = DateTime.Now,
                DateDue = correspondingNote.DateDue,
                DateModified = DateTime.Now,
                NoteType = correspondingNote.NoteType,
                Subject = correspondingNote.Subject,
                SenderRole = senderRole
            };

            NoteLink link = new NoteLink()
            {
                DateCreated = DateTime.Now,
                NoteID1 = correspondingNote.NoteID,
                NoteID2 = note.NoteID
            };
            db.Notes.Add(note);
            db.NoteLinks.Add(link);
            await db.SaveChangesAsync();
        }
        public List<CorrespondenceView> GetNotesForAdviserByUserId(string adviserUserId, int noteType)
        {
            List<CorrespondenceView> result = new List<CorrespondenceView>();
            var adviser = db.Adviser_Details.SingleOrDefault(ad => ad.AdvisorUserId == adviserUserId);
            var adviserId = adviser.AdvisorUserId.ToString();
            var relevantNoteType = noteType;
            foreach (var note in db.Notes.Where(n => n.AdviserID == adviserId &&
                n.NoteType == relevantNoteType && db.NoteLinks.Where(l => l.NoteID2 == n.NoteID).Count() == 0))
            {
                var client = db.Client_Details.SingleOrDefault(c => c.UserId == note.Client.ClientUserID);
                var resource = note.Attachments.FirstOrDefault();
                #region create correspondence payload skeleton first
                CorrespondenceView item = new CorrespondenceView()
                {
                    adviserId = adviser.AdvisorUserId.ToString(),
                    adviserName = adviser.FirstName + " " + adviser.LastName,
                    clientId = note.ClientID,
                    clientName = client.ClientType == BusinessLayerParameters.clientType_person ? client.FirstName + " " + client.LastName : client.EntityName,
                    date = note.DateCreated,
                    noteId = note.NoteID,
                    path = resource == null ? "" : System.Web.VirtualPathUtility.ToAbsolute(resource.Path),
                    subject = note.Subject,
                    typeName = CommonHelpers.GetEnumDescription((NoteTypes)note.NoteType),
                    type = resource == null ? "" : resource.AttachmentType,
                    conversations = new List<CorrespondenceConversation>(),
                    actionsRequired = note.FollowupActions,
                    assetClass = note.AssetClass,
                    completionDate = note.DateCompleted,
                    productClass = note.ProductClass
                };
                #endregion
                #region inject the initial conversation

                CorrespondenceConversation initial = new CorrespondenceConversation()
                {
                    content = note.Body,
                    createdOn = note.DateCreated,
                    senderRole = note.SenderRole,
                    senderName = note.SenderRole == BusinessLayerParameters.correspondenceSenderRole_adviser ? adviser.FirstName + " " + adviser.LastName
                    : (client.ClientType == BusinessLayerParameters.clientType_person ? client.FirstName + " " + client.LastName : client.EntityName)
                };
                item.conversations.Add(initial);
                #endregion
                #region insert all other conversations
                foreach (var subnote in db.NoteLinks.Where(n => n.NoteID1 == note.NoteID))
                {
                    var subNoteContent = db.Notes.SingleOrDefault(n => n.NoteID == subnote.NoteID2);
                    CorrespondenceConversation conversation = new CorrespondenceConversation()
                    {
                        content = subNoteContent.Body,
                        senderRole = subNoteContent.SenderRole,
                        createdOn = subNoteContent.DateCreated,
                        senderName = subNoteContent.SenderRole == BusinessLayerParameters.correspondenceSenderRole_adviser ? adviser.FirstName + " " + adviser.LastName
                        : (client.ClientType == BusinessLayerParameters.clientType_person ? client.FirstName + " " + client.LastName : client.EntityName)
                    };
                    item.conversations.Add(conversation);
                }


                #endregion
                item.conversations = item.conversations.OrderBy(s => s.createdOn).ToList();
                result.Add(item);
            }
            return result;
        }
        public List<CorrespondenceView> GetNotesForClientByUserId(string clientUserId, int noteType)
        {
            List<CorrespondenceView> result = new List<CorrespondenceView>();
            var client = db.Client_Details.SingleOrDefault(c => c.UserId == clientUserId);
            var clientId = db.Clients.SingleOrDefault(c => c.ClientUserID == clientUserId).ClientUserID;
            var relevantNoteType = noteType;
            foreach (var note in db.Notes.Where(n => n.ClientID == clientId &&
                n.NoteType == relevantNoteType && db.NoteLinks.Where(l => l.NoteID2 == n.NoteID).Count() == 0))
            {
                var adviser = db.Adviser_Details.FirstOrDefault(ad => ad.AdvisorUserId.ToString() == note.AdviserID);
                var resource = note.Attachments.FirstOrDefault();
                #region create correspondence payload skeleton first
                CorrespondenceView item = new CorrespondenceView()
                {
                    adviserId = adviser.AccountNumber.ToString(),
                    adviserName = adviser.FirstName + " " + adviser.LastName,
                    clientId = note.ClientID,
                    clientName = client.ClientType == BusinessLayerParameters.clientType_person ? client.FirstName + " " + client.LastName : client.EntityName,
                    date = note.DateCreated,
                    noteId = note.NoteID,
                    path = resource == null ? "" : System.Web.VirtualPathUtility.ToAbsolute(resource.Path),
                    subject = note.Subject,
                    typeName = CommonHelpers.GetEnumDescription((NoteTypes)note.NoteType),
                    type = resource == null ? "" : resource.AttachmentType,
                    conversations = new List<CorrespondenceConversation>(),
                    actionsRequired = note.FollowupActions,
                    assetClass = note.AssetClass,
                    completionDate = note.DateCompleted,
                    productClass = note.ProductClass
                };
                #endregion
                #region inject the initial conversation

                CorrespondenceConversation initial = new CorrespondenceConversation()
                {
                    content = note.Body,
                    createdOn = note.DateCreated,
                    senderRole = note.SenderRole,
                    senderName = note.SenderRole == BusinessLayerParameters.correspondenceSenderRole_adviser ? adviser.FirstName + " " + adviser.LastName
                    : (client.ClientType == BusinessLayerParameters.clientType_person ? client.FirstName + " " + client.LastName : client.EntityName)
                };
                item.conversations.Add(initial);
                #endregion
                #region insert all other conversations
                foreach (var subnote in db.NoteLinks.Where(n => n.NoteID1 == note.NoteID))
                {
                    var subNoteContent = db.Notes.SingleOrDefault(n => n.NoteID == subnote.NoteID2);
                    CorrespondenceConversation conversation = new CorrespondenceConversation()
                    {
                        content = subNoteContent.Body,
                        senderRole = subNoteContent.SenderRole,
                        createdOn = subNoteContent.DateCreated,
                        senderName = subNoteContent.SenderRole == BusinessLayerParameters.correspondenceSenderRole_adviser ? adviser.FirstName + " " + adviser.LastName
                        : (client.ClientType == BusinessLayerParameters.clientType_person ? client.FirstName + " " + client.LastName : client.EntityName)
                    };
                    item.conversations.Add(conversation);
                }


                #endregion
                item.conversations = item.conversations.OrderBy(s => s.createdOn).ToList();
                result.Add(item);
            }
            return result;
        }




    }
}