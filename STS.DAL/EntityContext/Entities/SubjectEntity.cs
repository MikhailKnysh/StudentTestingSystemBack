using System;
using System.ComponentModel.DataAnnotations;

namespace STS.DAL.EntityContext.Entitieas
{
    public class SubjectEntity
    {
        [Key]
        Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        string Title { get; set; }
    }
}