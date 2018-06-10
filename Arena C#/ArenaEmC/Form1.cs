using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaEmC {
    public partial class Form1 : Form {
        
        Random RandomAttack = new Random(); //Ataque aleatorio da maquina
        string RandomChoice;
        string CombatText;//String que aparece quando os herois atacam
        Combat Judge = new Combat(); //Cria o administrador do combate (calculo de dano etc)
        HeroGenerator Gen = new HeroGenerator(); //Cria o objeto Gen que guarda todos os valores dos personagens
        Hero player = new Hero(); //Cria o heroi do jogador
        Hero Enemy = new Hero();
        bool P2 = false; //Boolean que checa se o primeiro jogador ja escolheu e tambem serve para checar se ha 2 jogadores
        bool IsCombat = false; //Diz se o combate comecou

 

        private void labelColorReset() { //Limpa a tela de escolha para comecar o jogo
            Att1Label.ForeColor = Color.Black;
            Att2Label.ForeColor = Color.Black;
            SpecialLabel.ForeColor = Color.Black;
            Att1Label.BorderStyle = System.Windows.Forms.BorderStyle.None;
            Att2Label.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SpecialLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;

            }
        private void SelectLabel(Label LAB) {
            LAB.ForeColor = Color.Orange;
            LAB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            }


        public void ClearScreen() {
            UseHeroButton.Visible = false;
            SoloCheckBox.Visible = false;
            comboBox1.Visible = false;
            ShowTurnLabel.Visible = true;
            ShowTurnLabel.Location = comboBox1.Location;
            EnemyNameLabel.Visible = true;
            EnemyHPLabel.Visible = true;
            ProtectButton.Visible = true;
            AttackButton.Visible = true;
            DoNothingButton.Visible = true;

            }

        //Atualiza a tela com o personagem selecionado
        public void UpdateScreen(int Reference, int HP, int Stamina, decimal Defense) {
            HPStLabel.Text = "HP: " + HP + "/" + Gen.HeroHP[Reference] + ("    ") + " Stamina: "
                + Stamina + ("    ") + "Defence: "
                + (int)(((Defense * 100m) - 100m)*(-1)) + "%";
            Att1Label.Text = "PRIMARY ATTACK: " + Gen.HeroAttName[Reference]
                + "\n " + Gen.HeroAttDamage[Reference] + " Damage" + ", Cost: "
                + Gen.HeroAttCost[Reference] + " Stamina" + " (" + Gen.HeroAttChance[Reference] + "%)";
            Att2Label.Text = "SECONDARY ATTACK: " + Gen.HeroAttName2[Reference]
                + "\n " + Gen.HeroAttDamage2[Reference] + " Damage" + ", Cost: "
                + Gen.HeroAttCost2[Reference] + " Stamina" + " (" + Gen.HeroAttChance2[Reference] + "%)";
            ShowTurnLabel.Text = Gen.HeroName[Reference];
            SpecialLabel.Text = "SPECIAL: " + Gen.HeroSpecialName[Reference] + " Cost: "
                + Gen.HeroSpecialCost[Reference] 
                + "\n"  + Gen.HeroSpecialDesc[Reference];
            }
        public void UpdateEnemyScreen(int reference,int HP) { //Atualiza a tela do inimigo
                EnemyHPLabel.Text = "HP: " + HP + "/" + Gen.HeroHP[reference];
                EnemyNameLabel.Text = "" + Gen.HeroName[reference];
                }
        public Form1() {
            InitializeComponent(); //AO INICIAR!!!

            foreach (string i in Gen.HeroName) { //Adiciona os herois a lista
                comboBox1.Items.Add(i);
                }
            //Comecar o programa ja com o primeiro heroi selecionado
            comboBox1.SelectedIndex = 0;
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            //O index da lista e o mesmo do personagem e seus status
            //nas listas do Gen, aqui ele so pega o index e mostra os valores
            int ID = comboBox1.SelectedIndex;

            UpdateScreen(ID,Gen.HeroHP[ID],Gen.HeroStamina[ID],Gen.HeroDefence[ID]);
            if (ID == player.ID) { //Checa se o personagem ja foi escolhido
                MessageBox.Show("This Character is being used by Player 1\n Please choose another.");
                UseHeroButton.Enabled = false;
                }
            else {
                UseHeroButton.Enabled = true;
                }
            }

        private void button1_Click(object sender, EventArgs e) {
            int ID = comboBox1.SelectedIndex;
            //Gerando Inimigo
            if (SoloCheckBox.Checked) {
                int ID2 = ID; //Usado para gerar o ID do inimigo aleatoriamente
                while (ID2 == ID) {
                    ID2 = Gen.Generate();
                    }
                Gen.CreateHero(player, ID, Gen);
                Gen.CreateHero(Enemy, ID2, Gen);
                UseHeroButton.Enabled = false;
                comboBox1.Enabled = false;
                SoloCheckBox.Enabled = false;
                ClearScreen(); //Prepara a tela

                UpdateScreen(player.ID,player.HP,player.Stamina,player.Defense); //Esses dois metodos atualizam a tela para o combate
                UpdateEnemyScreen(Enemy.ID, Enemy.HP);//esse atualiza a tela do inimigo somente.

                IsCombat = true;
                }
            else {
                if (P2) { //Se o player 1 e 2 ja escolheram, iniciar o jogo
                    Gen.CreateHero(Enemy, ID, Gen);
                    UseHeroButton.Enabled = false;
                    comboBox1.Enabled = false;
                    ClearScreen();
                    UpdateScreen(player.ID, player.HP,player.Stamina,player.Defense);
                    UpdateEnemyScreen(Enemy.ID, Enemy.HP);
                    IsCombat = true;
                    }
                else { //Se so o player 1 escolheu, pedir para o player 2 escolher
                    MessageBox.Show("Please Choose the Player 2 Character");
                    Gen.CreateHero(player, ID, Gen);
                    SoloCheckBox.Enabled = false;
                    //holder = ID;
                    P2 = true;
                    

                    }

                }
            }

        private void HPStLabel_Click(object sender, EventArgs e) {

            }

        private void AttackButton_Click(object sender, EventArgs e) {
            if (Judge.Turn == 1) { //Se for o turno do Player
                if (player.choice != "") {
                    labelColorReset();
                    Judge.Turn = 2;
                    if (P2 == false) {
                        UpdateScreen(player.ID, player.HP, player.Stamina, player.Defense);
                        UpdateEnemyScreen(Enemy.ID, Enemy.HP);
                        AttackButton.PerformClick(); //Fazer a IA clicar sozinha no botao attack
                        }
                    else {
                        MessageBox.Show("Player 2 turn...");
                        UpdateScreen(Enemy.ID, Enemy.HP, Enemy.Stamina, Enemy.Defense);
                        UpdateEnemyScreen(player.ID, player.HP);
                        }
                    }
                else {
                    MessageBox.Show("Please choose an attack");
                    }


                }
            else if (Judge.Turn == 2) {
                if (P2 == false && Enemy.choice == "") { ////Se for a IA que esta jogando com o inimigo...
                    while (Enemy.choice == "") {
                        RandomChoice = "" + RandomAttack.Next(3);
                        if (Judge.CheckStamina(Judge.Turn, player, Enemy, Gen, RandomChoice)) { //Se ele tem estamina
                            Enemy.choice = RandomChoice; //Deixar ele escolher
                            }
                        }

                    }
                if (Enemy.choice != "") {
                    //Os dois atacam
                    CombatText = Judge.Clash(player, Enemy, Gen);
                    CombatText += "\n" + Judge.Clash(Enemy, player, Gen);
                    CombatText += "\n[+1 Stamina to both]"; //TEMPORARIO!!!!!!!!!!!!!!!!!!!!!!
                    //Reseta a rodada
                    MessageBox.Show(CombatText);
                    labelColorReset();
                    CombatText = "";
                    if (P2) {
                        MessageBox.Show("Player 1 turn...");
                        }
                    UpdateScreen(player.ID, player.HP, player.Stamina, player.Defense);
                    UpdateEnemyScreen(Enemy.ID, Enemy.HP);
                    Enemy.choice = "";
                    player.choice = "";
                    Judge.Turn = 1;
                    //Caso alguem fique com vida negativa
                    if (player.HP <= 0 && Enemy.HP <= 0) {
                        MessageBox.Show("DRAW!");
                        Application.Restart();
                        }
                    else if (Enemy.HP <= 0) {
                        MessageBox.Show(Gen.HeroName[player.ID] + " is the winner!!!!!");
                        Application.Restart();
                        }
                    else if (player.HP <= 0) {
                        MessageBox.Show(Gen.HeroName[Enemy.ID] + " is the winner!!!!!");
                        Application.Restart();
                        }
                    else {
                        MessageBox.Show("Please choose an attack");
                        }
                    }
                }

            }


        private void Form1_Load(object sender, EventArgs e) {

            }

        private void Att1Label_Click(object sender, EventArgs e) {
            if (IsCombat && Judge.CheckStamina(Judge.Turn, player, Enemy,Gen, "1")) {
                labelColorReset();
                SelectLabel(Att1Label);

                }
            else if (IsCombat == false) { //Se estiver na tela de selecao, nada acontece
                }
            else {
                MessageBox.Show("You don't have enough stamina!!");
                }
            }

        private void Att2Label_Click(object sender, EventArgs e) {
            if (IsCombat && Judge.CheckStamina(Judge.Turn,player,Enemy,Gen,"2")) {
                labelColorReset();
                SelectLabel(Att2Label);

                }
            else if (IsCombat == false){
                }
            else {
                MessageBox.Show("You don't have enough stamina!!");
                }
            }

        private void ProtectButton_Click(object sender, EventArgs e) {
            Judge.CheckStamina(Judge.Turn, player, Enemy, Gen, "0");
            AttackButton.PerformClick();
            }

        private void ShowTurnLabel_Click(object sender, EventArgs e) {

            }

        private void DoNothingButton_Click(object sender, EventArgs e) {
            Judge.CheckStamina(Judge.Turn, player, Enemy, Gen, "4");
            AttackButton.PerformClick();
            }

        private void SpecialLabel_Click(object sender, EventArgs e) {
            if (IsCombat && Judge.CheckStamina(Judge.Turn, player, Enemy, Gen, "3")) {
                labelColorReset();
                SelectLabel(SpecialLabel);
                }
            else if (IsCombat == false) {
                }
            else {
                MessageBox.Show("You don't have enough stamina!!");
                }

            }
        }
    }
//Pedro Fontebasso Lemos