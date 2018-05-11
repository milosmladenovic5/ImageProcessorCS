# ImageProcessorCS
Short image processing application. Written in C# and .NET.

Besides basic convolutional filters, contains interesting features like image cropping and animating.


**Korisničko uputstvo**

**Sadržaj** {#sadržaj .TOCHeading}
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

![](media/image1.png){width="5.854166666666667in"
height="3.384283683289589in"}

Obzirom na to da nijedna slika nije učitana za prikaz u aplikaciji,
meniji za obradu slike su onemogućeni za odabir.

Učitavanje slike i elementi početnog ekrana
===========================================

Kao što je u pasusima iznad navedeno, aplikacija nudi učivanje ili
„obične" jpg, png, bmp slike ili učitavanje slike prethodno kompresovane
ovim alatom.

![](media/image2.png){width="6.5in" height="3.7576388888888888in"}

Nakon odabira željene slike za učivavanje, ona će se prikazati na radnoj
površini aplikacije, ispod menija:\
![](media/image3.png){width="6.5in" height="4.397916666666666in"}\
Aplikacija je resizeable, kako bi se slike koje su manje veličine dobro
prikazale na ekranu i videli svi detalji koji su promenjeni primenom
nekih od filtara. U dnu ekrana se nalazi statusna linija koja prikazuje
dimenzije slike u pikselima, kao i naziv iste.

Traka sa menijima i njeni elementi
==================================

Traka sa menijima se nalazi na vrhu aplikacije, ispod naziva i logoa i
nudi razne mogućnosti koje će dalje u ovom delu biti opisane, ali prvo
da vidimo njen izgled i sve podmenije:

![](media/image4.png){width="6.5in" height="0.21736111111111112in"}

![](media/image5.png){width="1.0416666666666667in"
height="0.9166666666666666in"}
![](media/image6.png){width="1.5416666666666667in"
height="1.1666666666666667in"}
![](media/image7.png){width="1.6145833333333333in"
height="0.4895833333333333in"}![](media/image8.png){width="1.6770833333333333in"
height="4.25in"}

![](media/image9.png){width="2.9166666666666665in"
height="1.8958333333333333in"}

Prvi i drugi meni su korisnički intuitivni i smatram da ih ne bi trebalo
objašnjavati. Jedino vredno napomene jeste da u meniju Edit stoje opcije
***Seam carving*** i ***Crop. Seam carving*** vrši smanjivanje širine
slike za onoliko piksela koliko navedemo u parametrima. Međutim, zbog
ograničenja samog algoritma, nije preporučljivo unositivrednosti veće od
100, jer će vrlo verovatno izvršiti deformaciju i bitnih delova slike.
***Crop*** opcija će biti prikazana na sledećih nekoliko screenshotova.

![](media/image10.png){width="5.5574475065616795in" height="3.3125in"}

![](media/image11.png){width="5.645833333333333in"
height="3.819382108486439in"}

![](media/image12.png){width="4.846779308836395in"
height="5.635416666666667in"}

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

![](media/image13.png){width="5.104166666666667in"
height="3.4643985126859143in"}

> ![](media/image14.png){width="5.332069116360455in"
> height="3.425398075240595in"}

2.  **"Contrast" --** menja kontrast slike u zavisnosti od unetog
    parametra. **Vrednost contrast parametra treba da bude između -100
    i 100.**

![](media/image15.png){width="4.979166666666667in"
height="3.37370406824147in"}

![](media/image16.png){width="6.5in" height="4.159027777777778in"}

3.  ![](media/image17.png){width="2.9479166666666665in"
    height="3.2284722222222224in"}![](media/image18.png){width="3.120833333333333in"
    height="3.09375in"}"**Grayscale"** -- prebacuje sliku iz običnog
    prikaza u prikaz svih nivoa sive.

4.  "**Color" --** primenjuje color filter nad slikom, nakon što
    uzastopno unesete vrednosti za crvenu, plavu i zelenu boju u input
    box.\
    \
    ![](media/image19.png){width="2.875in"
    height="3.1667902449693788in"}![](media/image20.png){width="2.762707786526684in"
    height="2.7708333333333335in"}

5.  "**Edge enhance" --** filter koji se primenjuje nad slikom da bi se
    naglasile ivice. **Vrednost parametra za edge enhance treba da bude
    od 0 do 30.\
    \
    **![](media/image21.png){width="2.8541666666666665in"
    height="2.873596894138233in"}
    ![](media/image22.png){width="2.8198272090988628in"
    height="2.7291666666666665in"}

Preostali filteri funkcionišu na identičan način.

Opcija *Animate*
----------------

![](media/image23.png){width="1.6458333333333333in" height="4.25in"}

Nakon izbora ove opcije najpre se otvaraju dva dijaloga za unos
parametara:

-   Prvi dijalog očekuje unos gornje granice vrednosti piksela (zbir R +
    G + B komponenata), aplikacija odbacuje sve piksele koji se nalaze
    ispot unete granice, i time ubrzava brzinu iscrtavanja .

-   Drugi dijalog očekuje unos parametra koji određuje broj piksela
    (ivica) koji se iscrtavaju odjednom. (**Napomena: Pri unosu najmanje
    dozvoljene vrednosti na slikama veće rezolucije moguće je blokiranje
    forme za animaciju sve dok se animacija ne završi.)**

> ![](media/image24.png){width="4.791666666666667in"
> height="1.5104166666666667in"}

Sledi uporedan prikaz originalne slike i animacije (u toku) respektivno
:

![](media/image25.png){width="6.5in" height="3.720138888888889in"}

![](media/image26.png){width="6.5in" height="3.939583333333333in"}

Undo / Redo
-----------

![](media/image27.png){width="1.53125in" height="1.1458333333333333in"}

Mogućnost poništavanja poslednje operacije ili ponovnog primenjivanja
iste.

