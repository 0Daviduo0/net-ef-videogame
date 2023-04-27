using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("Software_house")]
    internal class SoftwareHouse
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("tax_id")]
        [StringLength(255)]
        public string Tax_id { get; set; }

        [Column("city")]
        [StringLength(255)]
        public string City { get; set; }

        [Column("country")]
        [StringLength(255)]
        public string Country { get; set; }

        public List<Videogame> Videogames { get; set; }

    }
}