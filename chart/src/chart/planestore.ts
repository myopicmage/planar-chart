import { writable } from 'svelte/store';

import type { Plane } from '../types';

export const planeStore = writable<Partial<Plane> | null>(null);