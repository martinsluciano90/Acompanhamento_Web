using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Acompanhamento_Web.Models
{
    public class Acompanhamento
    {
        [Key]
        public int ID { get; set; }
        [StringLength(20)] 
        [Required]
        public string CNPJ { get; set; } 
        [Required]
        public string RAZAO { get; set; }        
        [DataType(DataType.Date)]        
        [Required]
        public DateTime VALIDADE { get; set; }        
        public int DIAS { get; set; }        
        [DataType(DataType.Date)]        
        public DateTime NOTIFICACAO { get; set; }
        [StringLength(10)]
        public string AVISADO { get; set; }
        [StringLength(500)]
        public string ANOTACAO { get; set; }
        [StringLength(50)]        
        public string EMAIL1 { get; set; }
        [StringLength(50)]
        public string EMAIL2 { get; set; }        
    }
}
