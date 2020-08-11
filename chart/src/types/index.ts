export type Common = {
  id: number;
  locked: boolean;
  revealed: boolean;
}

export enum Ring {
  Center,
  Echoes,
  Chaos,
  WildReaches
}

export type Buff = Common & {
  name: string;
}

export type Location = Common & {
  PlaneId: number;
  name: string;
  description: string;
  buffs: Buff[];
  characters: Character[];
  quests: Quest[];
}

export type Plane = Common & {
  name: string;
  description: string;
  ring: Ring;
  buffs: Buff[];
  locations: Location[];
}

export type Character = Common & {
  locationId: number;
  name: number;
  race: string;
  description: number;
}

export enum QuestStatus {
  ToDo,
  InProgress,
  Complete,
  Abandoned
}

export type Quest = Common & {
  name: string;
  description: string;
  reward: string;
  giver?: Character;
  status: QuestStatus;
}

export const getProp = <T extends Common>(obj: T, prop: keyof T) =>
  obj.locked
    ? 'Locked'
    : obj[prop];