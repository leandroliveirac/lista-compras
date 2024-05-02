import { environment } from "../../../environments/environment.development";

export class API {
    static readonly BASE_URL = environment.baseUrl;

    static readonly ITENS_COMPRAS = `${API.BASE_URL}api/ItensCompra`
}