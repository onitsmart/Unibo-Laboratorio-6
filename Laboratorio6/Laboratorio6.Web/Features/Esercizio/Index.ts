module Features.Esercizio {
    export class indexViewModel {

        mostraMessaggi: boolean;

        constructor(public model: Features.Esercizio.Server.indexViewModel) {
            this.mostraMessaggi = false;
        }
    }
}