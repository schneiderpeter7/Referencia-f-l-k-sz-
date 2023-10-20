INSERT INTO FoglaltSzobak( foglalasID,ugyfelazon, szobaszam,kifizette)
Select Foglalas.foglalasID,Ügyfelek.ugyfelazon,SzobaTípus.szobaszam
From FoglaltSzobak, Foglalas,SzobaTípus,Ügyfelek
Where Foglalas.foglalasID=FoglaltSzobak.foglalasID AND SzobaTípus.szobaszam=FoglaltSzobak.szobaszam AND Ügyfelek.ugyfelazon=FoglaltSzobak.ugyfelazon

/*Select *
FROM Ügyfelek,Foglalas,FoglaltSzobak,SzobaTípus
Where Ügyfelek.ugyfelazon=FoglaltSzobak.ugyfelazon AND Foglalas.foglalasID=FoglaltSzobak.foglalasID 
AND SzobaTípus.szobaszam=FoglaltSzobak.szobaszam*/


