using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notas.Models
{
    internal class About
    {
        public string Title => AppInfo.Name;
        public string Nombre => "Justin Mora";
        public string MoreInfoUrl => "https://github.com/justxt";
        public string Message => "Hola mi nombres es Justin, pero me dicen Juss o Mateo, me gusta programar, me gustan los videojuegos y escuchar musica. Mi deporte favorito es nadar y voy al gym. PD: PUSE A ESE INSANO DE LA FOTO PQ SOY YO";
    }
}
