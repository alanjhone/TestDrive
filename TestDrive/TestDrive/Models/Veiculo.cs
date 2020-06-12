using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 1000;
        public const int AR_CONDICIONADO = 800;
        public const int MP3 = 500;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool TemFreioABS { get; set; }
        public bool TemArcondicionado { get; set; }
        public bool TemMp3 { get; set; }

        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor total: R$ {0}",
                    Preco +
                    (TemFreioABS ? FREIO_ABS : 0) +
                    (TemArcondicionado ? AR_CONDICIONADO : 0) +
                    (TemMp3 ? MP3 : 0)
                    );
            }
        }


}

}
