import { writable } from 'svelte/store';
import { Plane } from "../types"

export type Ring = {
  locked: boolean;
  name: string;
  planes: Partial<Plane>[];
}

export const rings = writable<Ring[]>([
  {
    locked: false,
    name: 'Prime material plane',
    planes: []
  },
  {
    locked: true,
    name: 'The Far Reaches',
    planes: [
      {
        id: 1,
        name: 'just a fucking spaceship',
        locked: true,
        description: "it's a fucking space ship"
      },
      {
        id: 2,
        name: 'just a fucking spaceship',
        locked: true,
        description: "it's a fucking space ship"
      },
      {
        id: 3,
        name: 'just a fucking spaceship',
        locked: true,
        description: "it's a fucking space ship"
      },
    ]
  },
  {
    locked: true,
    name: 'Planar boundaries',
    planes: [
      {
        id: 4,
        name: 'Elemental Plane',
        locked: true,
        description: "the elemental plane"
      },
      {
        id: 5,
        name: 'Elemental Plane',
        locked: true,
        description: "the elemental plane"
      },
      {
        id: 6,
        name: 'Elemental Plane',
        locked: true,
        description: "the elemental plane"
      },
    ]
  },
  {
    locked: true,
    name: 'Prime echoes',
    planes: [
      {
        id: 7,
        name: 'Feywild',
        locked: false,
        description: "An echo of the Prime Material Plane, skewing toward the light. The Fey make their home here."
      },
      {
        id: 8,
        name: 'The Shadowfell',
        locked: false,
        description: "An echo of the Prime Material Plane, skewing toward the shadow. Shadows are not inherently evil, but evil finds a home in shadow."
      },
      {
        id: 9,
        name: "Louie's Domain",
        locked: false,
        description: "A domain which, curiously, contains only a single person."
      }
    ]
  },
  {
    locked: false,
    name: 'Ephemeral Planes',
    planes: [
      {
        id: 10,
        name: 'Sphinxlandia',
        locked: false,
        description: "A beautiful, empty sky, save for a platform with a pyramid. A lone figure sits at the entrance, too far for you to see clearly"
      },
      {
        id: 11,
        name: 'Ethereal plane',
        locked: false,
        description: "The Ethereal Plane, barely an echo of the Prime Material Plane. Mages hide here."
      }
    ]
  },
]);