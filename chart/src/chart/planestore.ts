import { writable } from 'svelte/store';

import type { Plane } from '../types';

export type PlaneStore = {
  plane: Partial<Plane> | null;
  hover: boolean;
}

export const planeStore = writable<PlaneStore>({ plane: null, hover: false });