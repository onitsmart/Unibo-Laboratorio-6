declare module Features.Esercizio.Server {
	interface indexViewModel {
		messaggi: Esercizio.Server.messaggioViewModel[];
	}
}
declare module Esercizio.Server {
	interface messaggioViewModel {
		id: number;
		nomeUtente: string;
		testo: string;
		daMostrare: boolean;
		errore: boolean;
		coloreSfondo: string;
	}
}
