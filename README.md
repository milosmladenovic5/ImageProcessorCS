# ImageProcessorCS
Short image processing application. Written in C# and .NET.

Besides basic convolutional filters, contains interesting features like image cropping and animating.


**Korisničko uputstvo**

**Sadržaj** 
===========

[1 Uvod 2](#uvod)

[2 Početna stranica 3](#početna-stranica)

[3 Učitavanje slike i elementi početnog ekrana
4](#učitavanje-slike-i-elementi-početnog-ekrana)

[4 Traka sa menijima i njeni elementi
5](#traka-sa-menijima-i-njeni-elementi)

Korisničko uputstvo za Image processor

Uvod
====

Osnovni cilj aplikacije Image processor je, kao što joj i ime kaže,
obrada slika. Napravljena je kao projekat za studentsku praksu na 4.
godini Osnovnih studija na Elektronskom fakultetu -- smeru za
Računarstvo i informatiku. Aplikacija nudi:

1.  Učitavanje i čuvanje slike.

2.  Izmenu osnovnih paramatera slike kao što su: osvetljenje, kontrast i
    boje, dobijanje grayscale prikaza i sl.

3.  Primenu osnovnih filtara na sliku kao što su: Gaussian blur, Edge
    detect, Water, Sharpen, Flip, Swirl, Sphere, Time Warp i td.

4.  Undo i redo mogućnosti prilikom primene filtara.

5.  Primena algoritma „seam carving" - smanjivanje širine slike za
    željeni broj piksela duž vertikalnih putanja najmanje energije.

6.  Isecanje slike selektovanjem regiona koji na istoj želimo da
    isečemo.

Početna stranica
================

Kada se aplikacija startuje, početni ekran izgleda ovako:

![alt text](https://i.imgur.com/jMrxazB.png)


Obzirom na to da nijedna slika nije učitana za prikaz u aplikaciji,
meniji za obradu slike su onemogućeni za odabir.

Učitavanje slike i elementi početnog ekrana
===========================================

Kao što je u pasusima iznad navedeno, aplikacija nudi učivanje ili
„obične" jpg, png, bmp slike ili učitavanje slike prethodno kompresovane
ovim alatom.

![alt text](https://i.imgur.com/VkGsQRy.png)

Nakon odabira željene slike za učivavanje, ona će se prikazati na radnoj
površini aplikacije, ispod menija:\
![alt text](https://i.imgur.com/AZm0cTr.png)
Aplikacija je resizeable, kako bi se slike koje su manje veličine dobro
prikazale na ekranu i videli svi detalji koji su promenjeni primenom
nekih od filtara. U dnu ekrana se nalazi statusna linija koja prikazuje
dimenzije slike u pikselima, kao i naziv iste.

Traka sa menijima i njeni elementi
==================================

Traka sa menijima se nalazi na vrhu aplikacije, ispod naziva i logoa i
nudi razne mogućnosti koje će dalje u ovom delu biti opisane, ali prvo
da vidimo njen izgled i sve podmenije:

![alt text](https://i.imgur.com/1EaOYm4.png)

![alt text](https://i.imgur.com/h30vXs4.png)

![alt text](https://i.imgur.com/brATMKj.png)

![alt text](https://i.imgur.com/vhGqie4.png)

![alt text](https://i.imgur.com/kRqg3Kc.png)

![alt text](https://i.imgur.com/Kfm1iTk.png)


Prvi i drugi meni su korisnički intuitivni i smatram da ih ne bi trebalo
objašnjavati. Jedino vredno napomene jeste da u meniju Edit stoje opcije
***Seam carving*** i ***Crop. Seam carving*** vrši smanjivanje širine
slike za onoliko piksela koliko navedemo u parametrima. Međutim, zbog
ograničenja samog algoritma, nije preporučljivo unositivrednosti veće od
100, jer će vrlo verovatno izvršiti deformaciju i bitnih delova slike.
***Crop*** opcija će biti prikazana na sledećih nekoliko screenshotova.

![alt text](https://i.imgur.com/du3yEeR.png)

![alt text](https://i.imgur.com/7WXdV8G.png)


![alt text](https://i.imgur.com/KkUccEr.png)


Kako bi se isecanje slike i izvršilo pravilno **vrlo je bitno**
***selekciju vršiti od gornjeg levog ugla željene oblasti ka donjem
desnom uglu iste. ***

Sledeća stavka je meni „**Options**": U ovom meniju je ponuđena samo
jedna opcija, koja se odnosi na način izvršenja displacement filtera iz
sledećeg menija: ***smooth*** ili ne.

> U meniju **"Filters"** ponuđeni su svi filtri koji se nad učitanom
> slikom mogu izvršiti. Za svaki primenjeni filter je ponuđena I
> "*undo-redo"* opcija kako bi se videla razlika u odnosu na početnu
> sliku.

1.  " **Brightness " -** nakon unosa vrednosti koju želimo za promenu
    osvetljenja u dijalog koji nam je ponuđen, prikaz slike se promeni,
    kao na sledeće 2 slike:

![alt text](https://i.imgur.com/BukWjYT.png)


![alt text](https://i.imgur.com/W3Sv6qG.png)


2.  **"Contrast" --** menja kontrast slike u zavisnosti od unetog
    parametra. **Vrednost contrast parametra treba da bude između -100
    i 100.**
    
![alt text](https://i.imgur.com/Jg87za0.png)


![alt text](https://i.imgur.com/hWoB37d.png)

3.  ![alt text](https://i.imgur.com/hnUoPjE.png)
    
    ![alt text](https://i.imgur.com/2a7n9Q8.png)
    
    **Grayscale"** -- prebacuje sliku iz običnog
    prikaza u prikaz svih nivoa sive.

4.  "**Color" --** primenjuje color filter nad slikom, nakon što
    uzastopno unesete vrednosti za crvenu, plavu i zelenu boju u input
    box.\
    \
        ![alt text](https://i.imgur.com/f59ZRQP.png)

       ![alt text](https://i.imgur.com/3QG2VYS.png)


5.  "**Edge enhance" --** filter koji se primenjuje nad slikom da bi se
    naglasile ivice. **Vrednost parametra za edge enhance treba da bude
    od 0 do 30.\
    \
    **    ![alt text](https://i.imgur.com/FNsLetB.png)

         ![alt text](https://i.imgur.com/YW24iKq.png)


Preostali filteri funkcionišu na identičan način.

Opcija *Animate*
----------------

![alt text](https://i.imgur.com/Gr9PMmR.png)

Nakon izbora ove opcije najpre se otvaraju dva dijaloga za unos
parametara:

-   Prvi dijalog očekuje unos gornje granice vrednosti piksela (zbir R +
    G + B komponenata), aplikacija odbacuje sve piksele koji se nalaze
    ispot unete granice, i time ubrzava brzinu iscrtavanja .

-   Drugi dijalog očekuje unos parametra koji određuje broj piksela
    (ivica) koji se iscrtavaju odjednom. (**Napomena: Pri unosu najmanje
    dozvoljene vrednosti na slikama veće rezolucije moguće je blokiranje
    forme za animaciju sve dok se animacija ne završi.)**

![alt text](https://i.imgur.com/bTj57HI.png)


Sledi uporedan prikaz originalne slike i animacije (u toku) respektivno
:

![alt text](https://i.imgur.com/LfiwaFw.png)

![alt text](https://i.imgur.com/4fq4bKd.png)


Undo / Redo
-----------

![alt text](https://i.imgur.com/k0q9cIu.png)

Mogućnost poništavanja poslednje operacije ili ponovnog primenjivanja
iste.

