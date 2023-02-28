using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AutoMapper.Configuration.Annotations;

namespace Website.Entity.Entities
{
    public abstract class BaseEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKey Id { get; set; }

        [Ignore]
        public virtual DateTime CreateDate { get; set; }

        [Ignore]
        public int CreateUser { get; set; }

        [AllowNull]
        [Ignore]
        public virtual DateTime ModifyDate { get; set; }

        [AllowNull]
        [Ignore]
        public int ModifyUser { get; set; }

        public virtual void SetCreateDefault(int createUser, DateTime? createDate = null)
        {
            this.CreateUser = createUser;
            this.CreateDate = createDate == null ? DateTime.Now : createDate.Value;
        }

        public virtual void SetModifyDefault(int modifyUser, DateTime? modifyDate = null)
        {
            this.ModifyUser = modifyUser;
            this.ModifyDate = modifyDate == null ? DateTime.Now : modifyDate.Value;
        }
    }

    public abstract class BaseTreeEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimaryKey Id { get; set; }
        public TPrimaryKey ParentId { get; set; }
        public virtual string Type { get; set; }
        public virtual int Index { get; set; }
        public virtual int Order { get; set; }
        public virtual string CodeData { get; set; }

        [Ignore]
        public virtual DateTime CreateDate { get; set; }

        [Ignore]
        public int CreateUser { get; set; }

        [Ignore]
        [AllowNull]
        public virtual DateTime ModifyDate { get; set; }

        [Ignore]
        [AllowNull]
        public int ModifyUser { get; set; }

        public virtual void SetCreateDefault(int createUser, DateTime? createDate = null)
        {
            this.CreateUser = createUser;
            this.CreateDate = createDate == null ? DateTime.Now : createDate.Value;
        }

        public virtual void SetModifyDefault(int modifyUser, DateTime? modifyDate = null)
        {
            this.ModifyUser = modifyUser;
            this.ModifyDate = modifyDate == null ? DateTime.Now : modifyDate.Value;
        }
    }
}
