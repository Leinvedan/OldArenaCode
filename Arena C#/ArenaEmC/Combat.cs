using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaEmC {
    class Combat {


        //Valor que calcula a chance de acerto
        Random Hitchance = new Random();
        public int Turn = 1;
        private int BaseDamage = 0; //Usado APENAS para mostrar quando de dano foi protegido
        private int damage = 0;
        private int cost = 0;
        private int chance = 0;


        public string Clash(Hero attacker, Hero target, HeroGenerator gen) { //Aplica o dano no alvo
            //A string result dira na messagebox o que aconteceu.
            string result = gen.HeroName[attacker.ID];
            if (attacker.choice == "1") {
                damage = gen.HeroAttDamage[attacker.ID];
                cost = gen.HeroAttCost[attacker.ID];
                chance = gen.HeroAttChance[attacker.ID];

                }
            else if (attacker.choice == "2") {
                damage = gen.HeroAttDamage2[attacker.ID];
                cost = gen.HeroAttCost2[attacker.ID];
                chance = gen.HeroAttChance2[attacker.ID];
                }
            else if (attacker.choice == "3") {
                result += " used a SPECIAL ATTACK: "+ gen.HeroSpecialName[attacker.ID];
                UsedSpecial(attacker, target);
                cost = gen.HeroSpecialCost[attacker.ID];
                attacker.Stamina -= cost;
                return result;
                }
            else if (attacker.choice == "4") {
                result += " did nothing!!!\n(+2 Stamina)";
                attacker.Stamina += 3; //Estamina recebida normalmente + 1 de bonus
                return result;
                }
            attacker.Stamina -= cost;
            if (attacker.choice != "0") {
                int value = Hitchance.Next(100);
                if (value <= chance) {
                    if (target.choice == "0") {
                        BaseDamage = damage;
                        damage = (int)(damage * target.Defense);
                        target.HP -= damage;
                        result += " Attacked " + gen.HeroName[target.ID] + " with " + damage 
                            + " damage \n(Missed "+ (BaseDamage-damage) + " DMG)";
                        result += " (-" + cost+" stamina)";
                        BaseDamage = 0;
                        }
                    else {
                        target.HP -= damage;
                        result += " Attacked " + gen.HeroName[target.ID] + " with " + damage + " damage";
                        result += " \n(-" + cost + " stamina)";
                        }
                    }
                else {
                    result += " missed";
                    result += " (-" + cost + " stamina)";
                    }
                }
            else {
                result += " Tried to Block!";
                }
            attacker.Stamina += 2;
            //Resetando variaveis...
            damage = 0;
            cost = 0;
            chance = 0;
            return result;
            
            }

        public bool CheckStamina(int ROUND,Hero P1,Hero P2, HeroGenerator gen,string whichlabel) {
            Hero who; //Quem que a estamina esta sendo verificada
            int ActualCost = 0;
            if (ROUND == 1) {
                who = P1;
                }
            else {
                who = P2;
                }

            if (whichlabel == "1") {//Ataque 1
                ActualCost = gen.HeroAttCost[who.ID];
                }
            else if (whichlabel == "2") {//Ataque 2
                ActualCost = gen.HeroAttCost2[who.ID];
                }
            else if (whichlabel == "3") { //Especial
                ActualCost = gen.HeroSpecialCost[who.ID];
                }
            else if (whichlabel == "4") {//Fazer nada
                ActualCost = 0;
                who.choice = "4";
                }
            else if (whichlabel == "0") {//Defender
                ActualCost = 0;
                who.choice = "0";
                }

            if (who.Stamina < ActualCost) {
                return false;
                }
            else {
                who.choice = whichlabel;
                return true;
                }


            }

        public void UsedSpecial(Hero User, Hero Target) { 
            //Caso eu descubra como fazer uma lista de metodos...
            //Talvez eu consiga transformar esses 9 ifs numa lista...
            if (User.ID == 0) {
                ArcherSpecial(Target);
                }
            else if (User.ID == 1) {
                BarbarianSpecial(User);
                }
            else if (User.ID == 2) {
                WizardSpecial(Target);
                }
            else if (User.ID == 3) {
                NinjaSpecial(User);
                }
            else if (User.ID == 4) {
                PaladinSpecial(User);
                }
            else if (User.ID == 5) {
                SwordsWomanSpecial(Target, User);
                }
            else if (User.ID == 6) {
                OrcSpecial(Target, User);
                }
            else if (User.ID == 7) {
                WitchSpecial(Target, User);
                }
            else if (User.ID == 8) {
                RogueSpecial(Target);
                }
            }

        //Lista de Ataques especiais---------------
        private static void ArcherSpecial(Hero Target) {
            //Desc: Zera a estamina do inimigo e -50 vida
            Target.Stamina = 0;
            Target.HP -= 50;
            }
        private void BarbarianSpecial(Hero User) {
            //Desc: +10 estamina, +50 vida e -20% de defesa, entrando em furia
            User.Stamina += 15;
            User.Defense += 0.2m;
            User.HP += 50;
            }
        private void WizardSpecial(Hero Target) {
            //Desc: O alvo perde 100 de vida
            Target.HP -= 100;
            }
        private void NinjaSpecial (Hero User) {
            //Desc: +30 estamina
            User.Stamina += 30;
            }
        private void PaladinSpecial (Hero User) {
            //Desc: Defesa aumenta para 95%
            User.Defense = 0.05m;            
            }
        private void SwordsWomanSpecial (Hero Target,Hero User) {
            //Desc: Defesa aumenta em 20% e tira 20% do inimigo
            User.Defense -= 0.2m;
            Target.Defense += 0.2m;
            }
        private void OrcSpecial (Hero Target,Hero User) {
            //Desc: tira 150 de vida mas fica com 10% de defesa
            User.Defense = 0.9m;
            Target.HP -= 150;
            }
        private void WitchSpecial (Hero Target,Hero User) {
            //Desc: Da (estamina * 5) de dano no inimigo
            Target.HP -= (User.Stamina * 5);
            User.Stamina = 0;
            }
        private void RogueSpecial (Hero Target) {
            //Desc: Diminui a defesa do inimigo para 5%
            Target.Defense = 0.95m;
            }
        }
    }
//Pedro Fontebasso Lemos