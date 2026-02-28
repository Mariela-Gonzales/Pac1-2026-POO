using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonsApp.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        //Audit Fields
        [Column("created_by_id")]
        public string CreatedById { get; set; }
        
        [Column("created_date")]
        public string CreatedDate { get; set; }

        [Column("Update_by_Id")]
        public string UpdatedById { get; set; }

         [Column("Updated_date")]
        public string UpdatedDate { get; set; }

    }
}