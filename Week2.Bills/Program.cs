//Realizzare un’applicazione console che consenta
//di gestire le bollette di un utente.

//La bolletta ha Quota fissa (40 €), kWh consumati,
//Importo totale e Utente (intestatario).

//Inizializziamo un array con alcuni codici fiscali. 

//All'accesso, l'utente visualizza un menu
//in cui può scegliere di:
//1- calcolare la sua bolletta
//2- visualizzare le sue bollette
//3- uscire dal programma.

//1-calcolare la bolletta
//L'utente deve inserire il suo Codice Fiscale.

//SE il codice fiscale è tra quelli nell'array,
//L'utente inserisce i kW/h consumati, il suo nome
//e il suo cognome.
//A questo punto, viene calcolata la bolletta.
//L'importo della bolletta è dato da:
//quota fissa (40€) + kwH consumati * 10
//Una volta calcolata, stampare a video e
//su un file txt le informazioni della bolletta,
//codice fiscale, nome, cognome, kWh e importo da pagare.

//ALTRIMENTI, a video compare: 'Cliente non trovato'
//e si torna al menu principale.

//2- visualizzare le bollette,
//L'utente deve inserire il suo cf.

//SE il codice fiscale è tra quelli nell'array,
//recuperare il contenuto del file
//e mostrare a video SOLO le bollette associate
//al codice fiscale dell'utente

//ALTRIMENTI
//'Cliente non trovato'