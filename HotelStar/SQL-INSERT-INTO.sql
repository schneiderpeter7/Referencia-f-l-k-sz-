INSERT INTO FoglaltSzobak( foglalasID,ugyfelazon, szobaszam,kifizette)
Select Foglalas.foglalasID,�gyfelek.ugyfelazon,SzobaT�pus.szobaszam
From FoglaltSzobak, Foglalas,SzobaT�pus,�gyfelek
Where Foglalas.foglalasID=FoglaltSzobak.foglalasID AND SzobaT�pus.szobaszam=FoglaltSzobak.szobaszam AND �gyfelek.ugyfelazon=FoglaltSzobak.ugyfelazon

/*Select *
FROM �gyfelek,Foglalas,FoglaltSzobak,SzobaT�pus
Where �gyfelek.ugyfelazon=FoglaltSzobak.ugyfelazon AND Foglalas.foglalasID=FoglaltSzobak.foglalasID 
AND SzobaT�pus.szobaszam=FoglaltSzobak.szobaszam*/


