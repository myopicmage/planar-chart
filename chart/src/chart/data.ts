import { writable } from 'svelte/store';
import type { Plane } from "../types";

export const apiPlanes = writable<(Plane[])[]>([]);

export const loadPlanes = async () => {
  const result = await fetch('/api/plane/all');

  if (result.ok) {
    return await result.json();
  }
}
