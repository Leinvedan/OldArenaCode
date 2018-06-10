using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaEmC {
    class HeroGenerator {
        public string[] HeroName = { "Zero the Archer", "Evod the Barbarian", "Eliot the Wizad",
            "Nix the Ninja","Hanry the Paladin","Lily the Swordswoman","Urag the Orc","Kouris the Witch",
            "Bernard the Rogue"};
        public int[] HeroHP = { 200, 250, 190, 250, 300, 270, 301, 300, 205 };
        public int[] HeroStamina = { 6, 6, 5, 8, 6, 6, 5, 3, 10 };
        public decimal[] HeroDefence = { 0.7m, 0.6m, 0.8m, 0.7m, 0.5m, 0.6m, 0.4m, 0.8m, 0.75m };//Quantidade em % de dano que ira acertar o defensor
        public string[] HeroAttName = { "Basic Shot", "Axe Cut", "Fireball","Backstab","Stab",
            "Fast Cut","Orc Slash","Dark Magic","Surprise Attack"};
        public int[] HeroAttDamage = { 25, 40, 20, 35, 35, 35, 45, 15, 43 };
        public int[] HeroAttCost = { 2, 2, 1, 2, 2, 2, 3, 0, 5 };
        public int[] HeroAttChance = { 85, 80, 100, 90, 70, 80, 85, 100, 90 };
        public string[] HeroAttName2 = { "Triple Shot", "Heavy Strike", "Firestorm","Shuriken",
            "Divine Blade","Vertical Slash","Orc Fury!","Shadow Strike","Rogue's Secret"};
        public int[] HeroAttDamage2 = { 60, 100, 55, 70, 75, 65, 90, 40, 77 };
        public int[] HeroAttCost2 = { 4, 4, 3, 8, 5, 5, 5, 6, 6 };
        public int[] HeroAttChance2 = { 70, 40, 100, 65, 60, 80, 75, 90, 85 };
        public int[] HeroSpecialCost = { 8, 10, 16, 20, 15, 12, 20, 0, 18 };
        public string[] HeroSpecialName = {"Zero Shot!","Barbarian RAGE!","Eliot's Inferno!","Ninja Agility!",
            "Divine Wall!","Stance Change!","Urag's Fury!","Kouris Curse!","Invisibility!"};
        public string[] HeroSpecialDesc = { "(50 DMG, Enemy Stamina = 0)","(+10 STAM, +50HP,-20% DEF)",
            "(100 DMG)","(+30 STAM)","(DEF = 95%)","(+20% DEF, -20% Enemy DEF)","(DEF = 5%, 150 DMG)",
            "(DMG = (Stamina *5))","(Enemy DEF = 5%)"};
        Random ValueGen = new Random();
        public int Generate() {
            return ValueGen.Next(HeroName.Length);
            }

        //O codigo abaixo adiciona o valor das variaveis da lista ao objeto Hero
        public void CreateHero(Hero chosen, int reference, HeroGenerator generator) {

            chosen.HP = generator.HeroHP[reference];
            chosen.Stamina = generator.HeroStamina[reference];
            chosen.Defense = generator.HeroDefence[reference];
            chosen.ID = reference;
            }

        }
    }

