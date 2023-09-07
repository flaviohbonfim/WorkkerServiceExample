using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerServiceExample.Data.Entities;
public class BaseEntity
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // Chave primária e gerada automaticamente
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Configurar CreatedAt para preenchimento automático
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
}
