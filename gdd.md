-# Laughs For Sale

## Descripcion general

LaughsForSale es un juego de gestion de recursos donde tendrás que atender un negocio al que acudirán personas que busquen reirse.

## Jugabilidad

El juego trata de atender debidamente a todos los clientes que entren en el establecimiento. Para hacerlo, se contará con una serie de objetos que se podrán conbinar para generar otros. Si el cliente se rie, la transacción habrá sido beneficiosa, tu risómetro aumentará, por el contrario, si no se ríe, se considerará que has fallado en tu trabajo y tu risómetro bajará.

El juego contará con 7 dias jugables así como de varios finales a los que se podrá acceder dependiendo de tus decisiones a lo largo de la historia.

El boton para pausar estará situado arriba a la izquierda y cuando el juego sea pausado, aparecerá una caja y se instanciará un color negro difuminado para generar una sensación de pausa.

Cuando juegas partidas se guardará informacion sobre los objetos conseguidos.

### Finales
- Mal risómetro (bancarota): para acceder a este final, se debe tener un valor de risómetro deficiente.
- Buen risómetro (potencia creciente): para acceder a este final, se debe conseguir y mantener un valor de risómetro sobresaliente.
- Medio risómetro (mediocridad): para acceder a este final, se debe mantener un valor de risómetro medio.
- Polvo de la risa (): para obtener este final, debes 
- Final espacial: Para este final, debes hacer un trabajo excepcional al hacer reir a un alien que pueda aparecer en tu tienda durante los últimos días de la semana.

### Objetos

Existirán dos tipos de objetos, aquellos cuyo propósito es la creación de combos y por lo tanto no pueden ser utilizados por sí mismos y los elementos principales que se podrán utilizar individualmente.

Al empezar cada día, el jugador debe escoger 6 objetos de una lista que combinará con los 3 objetos de combo escogidos aleatoriamente:
- Gato: combo
- Matasuegras: solitario
- Palo: solitario
- Escobilla de bater: solitario
- Polvo de la risa: especial
- Muñeca: solitario
- Caca: combo 
- Cojín de aire: solitario
- papel de burbujas: solitario
- Metal Pipe: solitario
- Libro: combo 
- Videojuego: solitario
- Careta de payaso: solitario
- Pepino: solitario
- Pistola de agua: solitario
- Cosplay: solitario
- Cerillas: combo
- varita mágica: combo
- coche de juguete: solitario
- martillo: combo
- peluca: solitario
- globo: solitario
- silbato: solitario
- gafas graciosas: solitario
- cerveza: solitario
- paleta pin pon con cuerda: solitario
- Dibujo: solitario
- Peluche: solitario
- Pogo: solitario
- pato de goma: solitario
- unicornio: solitario
- Jack in the box: solitario
- chuches: solitario
- pelota: solitario
- tanque: solitario
- dinero: solitario
- Avion de papel: solitario

Habrá un total de 30 objetos primarios y 6 objetos de combo y cada día el jugador podrá escojer entre una pull de objetos paulatinamente más grande

Pull de objetos por día:

Dia 1: 9 objetos
Dia 2: 12
Dia 3: 15
dia 4 18
dia 5: 21
dia 6: 24
dia 7: 27
dia 8: 30

A mayores de los objetos, el jugador tendrá la posibilidad de contar un chiste bajo cierto riesgo, pues al cliente puede no hacerle gracia.

### Combos de Objetos

La tabla se encuentra en el archivo Comportamiento_Objetos.ods

### Clientes

Los clientes entrarán en fila, cada uno indicará la forma en la que el jugador debe hacerlos reir ya sea vocal o somáticamente (dibujos en su camisa), hacerlos reir aumentará el risómetro del jugador mientras que no hacerlos reir disminuirá el risómetro. Al final de cada día menos del primero, aparecerá un cliente 'jefe' al que hará falta un mayor esfuerzo para hacerle sonreir.

Los clientes aparecerán con un fade in cambiando el canal alpha y realizando una animación de subir y bajar, simulando el andar.

Los clientes serán:
- Otaku
- Fan de los gatos
- Policia: este cliente será relevante en la obtencion del final del polvo de la risa.
- Bruja
- Informático
- Artista
- Físico/Matemático
- Payaso
- Señor mayor
- Emo: Este cliente aparecerá a modo de 'jefe'.
- Futbolista
- Streamer/Youtuber
- Chef
- Traficante: este cliente será relevante en la obtencion del final del polvo de la risa.
- Conserje
- Niño
- Alien ???: este cliente será relevante en el final espacial.
- Fantasma ???: Este cliente resulta algo especial, aparecerá y dirá un chiste antes de irse.
- Rey
- Cura
- Hada
- hombre trajeado
- Comunista: Este personaje aparecerá a modo de jefe
- Jesucristo
- Mariachi
- Embarazada
- Preso
- Político
- psicópata: Este cliente aparecerá a modo de 'jefe' te apuñala si fallas
- Gordo
- Robot: Este cliente aparecerá a modo de 'jefe'
- Zombie: Este cliente aparecerá a modo de 'jefe'
- Perro humanoide
- Adolescente x1
- Adolescente x2
- Friki

Los personajes que se aparecerán al día ante el jugador deberan de mantener mínimo una sinergia neutra con alguno de los objetos seleccionados por el jugador.

### Mensajes

Estos serán los mensajes que dirán los personajes:

- Otaku_entrada: "Kon'nichiwa, Is it here were everyone comes to have fun?"
- Otaku_salida_mal: "That wasn't fun, you'll see me again once I've finished my ninjutsu trainning"
- Otaku salida_bien: "I have not felt like this since I discovered the one piece left on my cosplay"
- Fan de los gatos: "Hello, I think you might be able to change my Cat-itude"
- Fan de los gatos_mal: "You've got to be kitten me, What a CATastrophe"
- Fan de los gatos_bien: "I'm Feline good, that was purrfect for me"
- Bruja: "Bibidi Babidi Du joke or a curse upon you"
- Bruja_salida_bien: "Pretty good, I'll remember your doings when I strike"
- Bruja_salida_mal: "That was awfull, And people say I'm the witch?"
- Informático_entrada: "Hello World, may i have some laughs please?"
- Informatico_salida_bien: "This is the best since I dropped Windows"
- Informatico_salida_mal: "Wow, that was worse than javascript"
- Físico: 
- Fisico_salida_mal: 
- Fisico_salida_bien: "bad taste = stupidity * bad joke squared"
- Payaso:
- Payaso_salida_mal: "You'll also float, eventually"
- Payaso_salida_bien: 
- Señor mayor_entrada: "Greetings fellow shop assistant, would you mind making my day lighter?"
- Señor mayor_salida_mal: "Today's young people do not respect other people's time."
- Señor mayor salida_bien: "Jolly good joke! I can see a bright future upon your hands young man"
- Emo_entrada: "Hi I guess..., make me smile or whatever..."
- Emo_salida_mal: "How convenient, an empty attempt for an empty heart..."
- Emo_salida_bien: "That's pretty good, I had forgotten how good it feelt"
- Futbolista: "Goal wins"
- Futbolista_salida_mal: "I cant, i have football"
- Futbolista_salida_bien: "Tell your friends I was here"
- Streamer/Youtuber_entrada: "Mondongo"
- Streamer_salida_bien: "I must tweet how good that was"
- Streamer_salida_mal: "This is not a game, nothing is"
- Chef: "I'll order the house special"
- Chef_salida_bien: "Cooked to perfection, delicious"
- Chef_salida_mal: "I think you overcooked that one"
- Conserje
- Niño_entrada: "Hello, I'm sad and my mom sais you rock at making people laugh"
- Niño_salida_bien: "Hahaha, so funny, can I show that to my friends?"
- Niño_salida_mal: "That wasn't funny, I'll tell my mom 'bout you"
- Rey: "ugh, I hate stepping into tacky stores"
- Rey_salida_bien: "All this power and wealth and still, this commoners always make me laugh harder"
- Rey_salida_mal: "A hundred years ago, I would order you kill"
- Cura entrada: "Greetings son og God, I have seen better days, I think you know what to do know"
- Cura salida_bien: "I shall now expire your sins in return"
- Cura salida_mal: "That was not funny at all... I'll go to childs playground to cheer me up"
- Hada
- hombre trajeado
- Comunista: "Every day, my disdain for capitalism only becomes more pronounced"
- Comunista_bien: "I like you, Velcome to our land, my new potatoenjoyer friend!"
- Comunista_mal "It is seen that a rebellion was not enough"
- Jesucristo: "Greetings, son of God, it is I Jesus and I am here for you to please me"
- Jesucristo_bien: "My faith in humanity has been restored"
- Jesucristo_mal: "One flood was not enough"
- Mariachi: "Hola compadre, I cant concentrate in my music, can you help me?"
- Mariachi_bueno: "Así si!, I have a new rhythm to flow"
- Mariachi_mal: "Pinche pendejo, thats not funny at all"
- Robot: "GREETINGS FELLOW HUMAN"
- Robot_mal: "THAT WAS WORSE THAN THE BITE OF '87"
- Robot_bien: "HAR HAR HAR HAR, FUNNY JOKE I LAUGHED"
- Zombie: Este cliente aparecerá a modo de 'jefe'
- Perro humanoide_entrada: "Woof, Woof, I had a Ruff Day, can you cheer me up?"
- Perro humanoide_salida_bien: "Woof, Woof, that was Fur-real Bark-tastic"
- Perro humanoide_salida_mal: "Woof, Woof, I'm Woof-ly Sorry but I did not liked that"
- Adolescente x1 entrada: "You can really make people laugh? I-I mean for sure this is fake isn't it?"
- Adolescente x1 bien: "Hahahaha so funny, I mean, that was pretty good"
- Adolescente x1 mal: "Bite me, it's hilarious you consider that funny"
- Adolescente x2 entrada: "Update: entering an ol' boomer shop, i'm pretty sure this doesn't work"
- Adolescente x2 salida_mal: "Update: Worst place EVER, tldr, it wasn't funny at all, this person DEFINETLY doesn't know the drill"
- Adolescente x2 salida_bien: "Update: OH MY GOSH YOU GUYS HAVE TO CHECK THIS, IT WAS AWESOME"
- Friki entrada: "Hello Inkeeper, how about an exchange of goods and services?"
- Friki bien: "Haha, I commend joke, I shall now vanish from the store"
- Friki mal: "The wrath of heaven shall fall upon you, heretic"

### Combos con personajes

Cada personaje tendrá una serie de objetos preferidos y odiados


# Asignaciones

Funcionalidades Drag 'n Drop y hover-> Quique

Pantalla del menu de compra de seleccion de objetos -> Brais

Criba de Objetos (12 escoger 6 combo) y personajes -> Fernando y Lucas

Arte y diseño -> Diego


