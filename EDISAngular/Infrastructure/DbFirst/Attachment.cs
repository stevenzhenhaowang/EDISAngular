//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDISAngular.Infrastructure.DbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attachment
    {
        public string AttachmentId { get; set; }
        public string Title { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Path { get; set; }
        public System.DateTime DateModified { get; set; }
        public string Comments { get; set; }
        public byte Data { get; set; }
        public string AttachmentType { get; set; }
        public string NoteId { get; set; }
    
        public virtual Note Note { get; set; }
    }
}
