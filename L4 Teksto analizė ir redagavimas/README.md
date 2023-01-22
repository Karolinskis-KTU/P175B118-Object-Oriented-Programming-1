# LD4 Užduotis

4H-10. **Trumpiausi žodžiai.** 
Tekstiniame faile "Knyga.txt" duotas tekstas sudarytas iš žodžių, atskirtų skyrikliais. Skyriklių aibė žinoma. Raskite ir spausdinkite faile Rodikliai.txt:
* trumpiausių žodžių, bet ne trumpesnių nei 3 simboliai, sąrašą (ne daugiau nei 10 žodžių) ir jų pasikartojimo skaičių;
* ilgiausią (didžiausias žodžių kiekis) teksto fragmentą, sudarytą iš žodžių, kur žodžio paskutinė raidė sutampa su kito žodžio pirmąja raide (tarp didžiųjų ir mažųjų raidžių skirtumo nedaryti) ir juos skiriančių skyriklių, bei jo eilutės numerius;

Reikia teksto žodžius sulygiuoti, kad kiekvienos eilutės kiekvienas žodis prasidėtų fiksuotoje toje pačioje pozicijoje. Galima įterpti tik minimalų būtiną tarpų skaičių. Reikia šalinti iš pradinio teksto kelis iš eilės einančius vienodus skyriklius, paliekant tik vieną jų atstovą. Įterpimo taisyklę taikome, siekdami gauti lygiuotą minimalų tekstą. Pradinio teksto eilutės ilgis neviršija 80 simbolių.

Spausdinkite faile ManoKnyga.txt pertvarkytą tekstą pagal tokias taisykles:
* kiekvienos eilutės pirmasis žodis turi prasidėti pozicijoje p1=1.
* antrasis kiekvienos eilutės žodis turi prasidėti minimalioje galimoje pozicijoje p2, tokioje, kad kiekvienos eilutės pirmasis žodis kartu su už jo esančiais skyrikliais baigiasi iki p2-2 arba p2-1.
* trečiasis kiekvienos eilutės žodis turi prasidėti minimalioje galimoje pozicijoje p3, tokioje, kad kiekvienos eilutės antrasis žodis kartu su už jo esančiais skyrikliais baigiasi iki p3-2 arba p3-1.
* ir t.t.