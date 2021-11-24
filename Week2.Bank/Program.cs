//Scrivere un programma per la gestione dei conti in una banca.
//Un conto è un'entità che ha
//Cliente 
//Numero di conto (int)
//Saldo (decimal)

//Un cliente è un'entità che ha:
//Codice cliente (string)
//Nome 
//Cognome

//L’utente banchiere può:
//1. Creare un nuovo conto 
//2. Gestire il prelievo da un conto
//3. Gestire il versamento su un conto
//4. Visualizzare il saldo di un conto 
//5. Chiudere un conto

//1. Creare un nuovo conto
//- Generare un codice cliente random
//- Generare per ogni nuovo conto un numero di conto diverso da quelli già esistenti
//- Il saldo iniziale di un nuovo conto è 0

//Opzionale: 
//Se il cliente dichiara di essere già cliente, ovvero c'è già un conto con quel cliente,
//si può non chiedere nome e cognome ma ricavarli dal cliente associato al conto.

//2. 3. Prelevare / versare
//Si recupera il numero di conto, si recupera l’importo da prelevare/versare, si verifica
//se l’importo è valido (non posso prelevare più di quanto ci sia sul mio conto, non posso
//inserire un importo negativo) e si modifica il saldo del conto.

//Visualizzare il saldo di un conto
//Si recupera il conto di cui si vuole visualizzare il saldo
//e si stampa il saldo a video.

//Chiudere un conto
//Si recupera il conto da chiudere e si elimina.

