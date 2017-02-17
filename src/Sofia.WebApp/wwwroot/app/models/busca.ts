export interface ColaboradorViewModel {
    id: number;
    nome: string;
    tecnologias: TecnologiaViewModel[];
}

export interface TecnologiaViewModel {
    nome: string;
    icone: string;
    nivel: number;
    nivelPorExtenso: string;
}