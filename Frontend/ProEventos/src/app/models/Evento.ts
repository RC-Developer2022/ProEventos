import { Palestrante } from './Palestrante';
import { RedeSocial } from './RedeSocial';
import { Lote } from './Lote';

export interface Evento {
  id: number;
  local: string;
  dataEvento?: Date;
  tema: string;
  qtdPessoas: number;
  imagemURL: string;
  telefone: string;
  email: string;
  lotes: Lote[];
  redesSociais: RedeSocial[];
  palestrantes: Palestrante[];
}
