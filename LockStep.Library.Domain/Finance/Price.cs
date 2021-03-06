using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep.Library.Domain.Finance
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public Book Book { get; set; }
        public string Value { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
    }
}
