'use strict';
export var Global:
    {
        API: {
            tecnologias: string, busca: string
        },
        Version: string,
        Usuario: { id: number, nome: string, foto: string }
    } = {
        API: {
            tecnologias: "http://localhost:5000/v1/tecnologias",
            busca: "http://localhost:5000/v1/busca"
        },
        Version: "v1",
        Usuario: { id: 1, nome: "John Doe", foto: "http://www.q-meieriene.no/bundles/q/images/avatar_image.jpg?45df6b94" }
    };
