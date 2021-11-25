//Applicazione per gestire il noleggio di Veicoli.

// Il VEICOLO è caratterizzato da:
// - Targa
// - Modello 
// - Tariffa giornaliera

// I veicoli a noleggio sono furgoni e automobili.

//L'AUTOMOBILE ha anche:
//- numero di posti

//Il FURGONE ha anche:
//- capacità di carico espressa in kg.

//Il NOLEGGIO ha:
//- Id (identificativo)
//- Data di inizio,
//- Numero di giorni
//- Costo totale,
//- Codice fiscale del CLIENTE,
//- Targa del VEICOLO

//Il CLIENTE ha:
//- Nome,
//- Cognome, 
//- Codice fiscale

//Inizializzare una lista di clienti, di veicoli disponibili e
//di noleggi già esistenti (alcuni attivi e alcuni terminati)

//Noleggi
//ID; Targa;   CodiceFiscale;    DataInizio;     NumeroGiorni; Costo
//1;  AX743HJ; NREFBA76A01L219J; 22 / 11/ 2021;  5;            275
//2;  GJ924LR; NREFBA76A01L219J; 27 / 11 / 2021; 2;            120
//3;  UY248QW; NREFBA76A01L219J; 7 / 6 / 2020;   1;            65
//4;  AX743HJ; RSSMRA80A01L219M; 10 / 10 / 2021; 1;            70
//5;  TY467WE; RSSMRA80A01L219M; 22 / 11 / 2021; 5;            625
//6;  GH567KU; RSSMRA80A01L219M; 19 / 4 / 2020;  3;            600

//Clienti
//CodiceFiscale;    Nome;  Cognome
//RSSMRA76A01L219J; Mario; Rossi
//RSSMRC80A01L219M; Marco; Rossi

//Veicoli
//Targa;   Modello;            Tariffa; Posti / Capacità
//AX743HJ; Fiat Panda;         55;      4 (automobile)
//GJ924LR; Fiat Punto;         60;      5 (automobile)
//UY248QW; Fiat Tipo;          65;      5 (automobile)
//GK823NB; Smart fortwo coupè; 70;      2 (automobile)
//TY467WE; Fiat Ducato;        125;     750 (furgone)
//GH567KU; Fiat Fiorino;       100;     450 (furgone)

//All'accesso, l'utente può:
//1 Visualizzare tutti i noleggi, con i dati del veicolo e del cliente 
//2 Visualizzare i noleggi di un certo veicolo (input: targa)
//3 Visualizzare i dettagli di un certo noleggio (input: id)
//4 Inserire un nuovo noleggio, verificando che il veicolo non sia impegnato.
//Il costo del noleggio si calcola moltiplicando la tariffa per il numero
//di giorni.
//- Mostrare i veicoli noleggiabili -> il cliente sceglie un veicolo -> se è disponibile procedo con l'inserimento del noleggio,
//altrimenti 'Veicolo impegnato'.
//- Mostrare solo i veicoli liberi -> il cliente sceglie tra quelli -> procedo con l'inserimento
//Opzionale: se il cliente è nuovo, registro prima il cliente e poi il suo noleggio.
//5 Data una targa, calcolare il totale in euro dei noleggi
//6 Ricavare il totale in euro dei noleggi di automobili

using Week2.Rentals;

Menu.Start();