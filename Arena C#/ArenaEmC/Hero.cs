using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaEmC {
    class Hero {
        public int HP;
        public int Stamina;
        public decimal Defense;
        public int ID = -1;        //Numero referente ao heroi escolhido na matriz. -1 para nao dar conflito no inicio
        public string choice = ""; //Ataque escolhido durante o combate
        }
    }
