from random import randint
#inicio matriz de personagens
persnome=['Zero o arqueiro','Evod o barbaro','Eliot o mago','Nix a ninja','Hanry o paladino']#0 a 4
persnome2=['Lily a espadachim','Urag o orc','Kouris a bruxa','Bernard o gatuno']#5 a 8
persnome+=persnome2
#status=[vida,estamina]
status=[[200,6],[250,6],[190,5],[250,8],[300,6],[270,6],[301,5],[300,3],[205,10]]
#golpe 1 atributos(fraco)[dano,custo,chance]
golpe1=['Tiro basico','Dilacerar','Choque','Facada','Estocada','Corte rapido','Gancho de direita','Magia sombria','Ataque oculto']
golpe1atr=[[25,2,85],[40,2,80],[20,2,100],[35,1,90],[35,2,70],[35,2,80],[45,3,75],[15,0,100],[43,5,90]]
#golpe 2 atributos(forte)[dano,custo,chance]
golpe2=['Tiro triplo','Combo mortal','Bola de fogo','Shuriken','Lamina divina','Corte vertical','Esmaga cranio','Ataque das sombras','Golpe secreto']
golpe2atr=[[60,4,70],[100,4,40],[55,3,100],[95,15,65],[75,5,60],[65,5,80],[80,4,50],[75,3,90],[77,6,85]] 
#especiais
especial=['Chuva de flechas','Modo furia','Miasma','Agilidade','Aura sagrada','Sequencia','Golpe vital','Banimento','Imitacao']
especialstatus=[0,'furioso(+2 vida e +1 estamina)','evenenado(-10 de vida)','Veloz(+2 estamina)','Iluminado(+5 de vida)',0,'Quebrado(-1 estamina)',0,0]
especdesc=['Dano entre 50 e 180','+2 de vida e +1 de estamina por turno','Envenena o alvo -10','+2 de estamina por turno','+5 de vida por turno']
especdesc2=['Ataca com 135 de dano','Diminui a regeneracao de estamina do inimigo (-1)','Elimina o alvo','Dano aleatorio entre 0 e 150']
especdesc+=especdesc2
especcusto=[7,5,5,15,10,12,11,15,8]
for i in range(0,len(especial)): #junta tudo numa lista
    especial[i]=[especial[i],especcusto[i],especialstatus[i],especdesc[i],0]
    golpe1[i]=golpe1atr[i]+[golpe1[i]]
    golpe2[i]=golpe2atr[i]+[golpe2[i]]
    
#especial=[[nome,custo de estamina,status(aparece na luta),descricao,se usou o especial]]
#golpex=[[dano,custo,chance,nome]]
    
#a lista especialref que designa se o especial e buff,debuff ou dano puro
#0 significa que o especial nao pertence aquela lista
efeitos=[[50,181],[2,1],[-10,0],[0,2],[10,0],[135,136],[0,-1],[4999,5000],[0,151]]

especial_direcional=['danopuro','buff','debuff','buff','buff','danopuro','debuff','danopuro','danopuro']
especial_lista=[efeitos,especial_direcional]
#ex zero usou especial: especial_efeitos[0][0], kouris: especial_efeitos[7][7]
derrotados=[]
#fim da matriz--------------------------------------------------------------------------------------------------------------------------------------------------
def regras():
    print 'REGRAS!'
    print '1-> Ambos os jogadores escolhem os movimentos e\naque sao executados ao mesmo tempo.'
    print '2-> Cada jogador comeca com uma quantidade de\nestamina(que varia dependendo do personagem).'
    print '3-> Cada ataque possui um custo de estamina,\nchance de acerto e dano.'
    print '4-> A cada turno, ambos recuperam 2 de estamina'
    print '5-> O jogador pode se proteger ou nao gastando 3 pontos de estamina.'
    print '6-> Ao se proteger o jogador:'
    print '6.1-> Anula qualquer efeito secundario dos especiais'
    print '6.2->Reduz o dano em 75%'
    print '7->Cada personagem possui um especial\ndiferente.'
    print '8->O modo sobrevivencia:'
    print '8.1->O jogador luta contra todos os personagens\nnuma ordem aleatoria'
    print '8.2->A cada vitoria, os atributos do\njogador sao restaurados.'
    enter=raw_input('Pressione enter para continuar')
    print '\n'*10
    return()

def modo(): #funcao que define o modo de jogo
    print '[Ref]---Modo de jogo'
    print '[ 1 ]---Modo P1 vs P2'
    print '[ 2 ]---Modo P1 vs PC(PC aleatorio)'
    print '[ 3 ]---Modo P1 vs PC(Escolher PC)'
    print '[ 4 ]---Modo Sobrevivencia'
    # lista=[[sozinho,escolher_adversario,sobrev]]
    lista=[['N','S','N'],['S','N','N'],['S','S','N'],['S','N','S']]
    while True:
        try:
            k=abs(int(raw_input('Digite a referencia '))) #referencia
            print '\n'*10
            if k>5 or k<1:
                raise
            else:
                modo=lista[k-1]
                break
        except:
            print'Erro, caracter invalido'
    
    return(modo)
def escolha(modo,stats,nomes,golpeA,golpeB,especialA):
    jogadores=0
    escolhidos=[]
    while True:
        print'--------------JOGADOR {:d}--------------'.format(jogadores+1)
        print'[ref]-Nome'
        for k in range(0,len(nomes)):
            print'[{:^3d}]-{:15s}'.format(k,nomes[k])
        while True:
            try:
                val=abs(int(raw_input('Digite a referencia ')))
                if val>=len(nomes) or val in escolhidos:
                    raise
                else:
                    print '\n'*10
                    break
            except:
                print'**Erro**'
        print '{:#^40s}'.format('LISTA DE MOVIMENTOS')
        print 'Voce escolheu {:s}'.format(nomes[val].upper())
        print 'VIDA({}),ESTAMINA({})'.format(stats[val][0],stats[val][1])
        print '({:15s})custa {:d},dano {:d}({:d}%)'.format(golpeA[val][3],golpeA[val][1],golpeA[val][0],golpeA[val][2])
        print '({:15s})custa {:d},dano {:d}({:d}%)'.format(golpeB[val][3],golpeB[val][1],golpeB[val][0],golpeB[val][2])
        print '({:15s})custa {:d},{:s}'.format(especialA[val][0],especialA[val][1],especialA[val][3])
        print 40*'#'
        print 'tem certeza?(S/N)'
        while True:
            try:
                resp=raw_input('resposta ').upper()
                print '\n'*10
                if resp not in ['S','N']:
                    raise
                else:
                    print '\n'*10
                    break
            except:
                print 'Erro, caracter invalido'
        if resp=='S':
            if jogadores==0:
                ref=val
                if modo[0]=='S' and modo[1]=='N' or modo[2]=='S':
                    jogadores=2
                    inim=ref
                    while inim==ref:
                        inim=randint(0,len(nomes)-1)
                    break
                elif modo[1]=='S':
                    jogadores+=1
                    escolhidos.append(ref)
            elif jogadores==1:
                inim=val
                break
        else:
            continue
    return(ref,inim)
#------Classe jogador----------
class jogador():
    def atributos(self,ref,nome,stat,ataque1,ataque2,espec,especL):
        self.ref=ref
        self.nome=nome[ref]
        self.vidaB=stat[ref][0]
        self.vida=stat[ref][0]
        self.estaminaB=stat[ref][1]
        self.estamina=stat[ref][1]
        self.especialL=especL
        self.tudo=[[0,0,100,'Nada']]+[ataque1[ref]]+[ataque2[ref]]+[espec[ref]]+[[0,3,100,'Proteger']]
        self.ativo=False
        self.modificadores=[0,0]
        self.oqfz=''
        self.dano=0
    def atualizar(self,vida,estamina,modificadores):
        self.vida+=self.modificadores[0]
        self.estamina+=self.modificadores[1]+3
        
#------Classe jogador----------

#----------------Funcao Tela----------
def tela(jog,inimigo):
    print '\n'*20
    print 'VEZ DE {:s}'.format((jog.nome).upper())
    print '[{:d}] VIDA, [{:d}] ESTAMINA'.format(jog.vida,jog.estamina) 
    print '[Ref]-nome-custo-dano-chance'
    print '[ 0 ](Fazer Nada     )custa 0'
    print '[ 1 ]({:15s})custa {:d},dano {:d}({:d}%)'.format(jog.tudo[1][3],jog.tudo[1][1],jog.tudo[1][0],jog.tudo[1][2])
    print '[ 2 ]({:15s})custa {:d},dano {:d}({:d}%)'.format(jog.tudo[2][3],jog.tudo[2][1],jog.tudo[2][0],jog.tudo[2][2])
    if not jog.ativo:
        print '[ 3 ]({:15s})custa {:d},{:s}'.format(jog.tudo[3][0],jog.tudo[3][1],jog.tudo[3][3])
    else:
        print 'ESPECIAL JA ATIVO'
    print '[ 4 ](Proteger-se    )custa 3'
    print 'Seu inimigo possui [{}] de vida'.format(inimigo.vida)
    
#----------------Funcao Tela----------

#-----------------Funcao IA------------------
def ia(jog):
    if jog.estamina>1:
        if jog.vida<(0.6)*(jog.vidaB):
            prot=randint(0,100)#Modo defensivo
        else:
            prot=0
    if prot>70 and jog.estamina>=3:
        ataq=4
    elif prot<=70:
        if jog.estamina<jog.tudo[1][1]:
            ataq=0
        elif jog.estamina>=jog.tudo[3][1] and not jog.ativo:
            probespec=randint(0,100)
            if probespec<80:
                ataq=3
            else:
                ataq=randint(1,2)
        elif jog.estamina>=jog.tudo[2][1]:
            ataq=randint(1,2)
        elif jog.estamina>=jog.tudo[1][1]:
            ataq=randint(0,1)
    return(ataq)
#-----------------Funcao IA------------------
    
#----------Funcao Combate--------------------
def combate(jog,inimigo,maquina):
    while True:
        dano=0
        prot=1
        jog.oqfz=''
        try:
            if not maquina:
                att=int(raw_input('Digite a referencia: '))
                if att<0 or att>4:
                    raise
            else:
                att=ia(P2)
        except:
            print'Valor invalido'
            continue
        if jog.tudo[att][1]<=jog.estamina:
            jog.estamina-=jog.tudo[att][1]
            if att==0:
                jog.oqfz='nao fez nada'
            elif att==3:
                jog.oqfz='usou {}'.format(jog.tudo[3][0])
                if jog.especialL[1][jog.ref]=='buff':
                    jog.modificadores=jog.especialL[0][jog.ref]
                elif jog.especialL[1][jog.ref]=='debuff':
                    inimigo.modificadores=jog.especialL[0][jog.ref]
                    print inimigo.modificadores
                elif jog.especialL[1][jog.ref]=='danopuro':
                    dano=randint(jog.especialL[0][jog.ref][0],jog.especialL[0][jog.ref][1])
            elif att==4:
                jog.oqfz='se protegeu'
                prot=4
            else:
                chance=randint(0,100)
                if chance>jog.tudo[att][2]*0.9:
                    jog.oqfz='critico'
                    dano=(jog.tudo[att][0])*2
                elif chance<jog.tudo[att][2]:
                    dano=(jog.tudo[att][0])
                else:
                    jog.oqfz='Errou'
        else:
            print 'Voce nao possui estamina o suficiente!'
            continue
        break
    jog.dano=dano
    return(prot)
        

#----------Funcao Combate--------------------
#----------------------------programa principal----------------------------
estilo=modo()
jog1,jog2=escolha(estilo,status,persnome,golpe1,golpe2,especial)
P1=jogador()
P2=jogador()
P1.atributos(jog1,persnome,status,golpe1,golpe2,especial,especial_lista)
P2.atributos(jog2,persnome,status,golpe1,golpe2,especial,especial_lista)
turno=1
derrotados=[jog1]
print '[{}]----VS----[{}]'.format(P1.nome,P2.nome)
ok=raw_input('Enter para continuar')
print 20*'\n'
while True:
    #player 1
    if estilo[0]=='N':
        ok=raw_input('Vez do jogador 1')
    tela(P1,P2)
    prot1=combate(P1,P2,False)
    #player 2
    if estilo[0]=='N':
        print 20*'\n'
        ok=raw_input('Vez do jogador 2')
        tela(P2,P1)
        prot2=combate(P2,P1,False)
    else:
        prot2=combate(P2,P1,True)
    #resultados
    P1.atualizar(P1.vida,P1.estamina,P1.modificadores) #aplica os modificadores
    P2.atualizar(P2.vida,P2.estamina,P2.modificadores)
    P1.vida-=P2.dano/prot1 #aplica o dano
    P2.vida-=P1.dano/prot2
    print 20*'\n'
    print '-------Fim do turno {}-------'.format(turno)
    turno+1
    if P1.dano>0:
        if P1.oqfz=='critico':
            print '{:*^20s}'.format('Critico')
        print '{} acertou {} com {} de dano!!!!'.format(P1.nome,P2.nome,P1.dano)
    else:
        print '{} {}'.format(P1.nome,P1.oqfz)
        if P1.oqfz=='nao fez nada':
            recup=int(P1.vida*0.2)
            P1.vida+=recup
            if P1.vida>P1.vidaB:
                P1.vida=P1.vidaB
            print '{} recuperou {} pontos de vida'.format(P1.nome,recup)
    if P2.dano>0:
        if P2.oqfz=='critico':
            print '{:*^20s}'.format('Critico')
        print '{} acertou {} com {} de dano!!!!'.format(P2.nome,P1.nome,P2.dano)
    else:
        print '{} {}'.format(P2.nome,P2.oqfz)
        if P2.oqfz=='nao fez nada':
            recup=int(P2.vida*0.2)
            P2.vida+=recup
            if P2.vida>P2.vidaB:
                P2.vida=P2.vidaB
            print '{} recuperou {} pontos de vida'.format(P2.nome,recup)
    print '-------Inicio do turno {}-------'.format(turno)
    ok=raw_input('Enter para continuar')
    if P1.vida<=0 and P2.vida<=0:
        print 'Houve um empate!!!!'
        ok=raw_input('Enter para continuar')
        continue
    elif P1.vida<=0:
        print '{} foi derrotado(a)!!!!!'.format(P1.nome)
        break
    elif P2.vida<=0:
        print '{} foi derrotado(a)!!!!!'.format(P2.nome)
        if estilo[2]=='S':
            derrotados.append(P2.ref)
            print 20*'\n'
            print'Voce derrotou {} guerreiros!!!'.format(len(derrotados)-1)
            while jog2 in derrotados:
                jog2=randint(0,len(persnome)-1)
            P2.atributos(jog2,persnome,status,golpe1,golpe2,especial,especial_lista)
            recup=int(0.3*P1.vida)
            P1.vida+=recup
            print 'Voce recuperou {} pontos de vida!!!!'.format(recup)
            print 'Seu proximo adversario sera {}!!!!'.format(P2.nome)
            ok=raw_input('Enter para continuar')
        elif len(derrotados)==len(persnome) or estilo[2]=='N':
            print 'FIM'
            break
    
    
