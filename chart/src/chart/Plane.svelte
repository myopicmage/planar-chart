<script lang="ts">
  import type { Plane } from "../types";
  import { push } from 'svelte-spa-router';

  import { planeStore } from './planestore';

  export let plane: Partial<Plane>;
  export let planeid: number = 0;
  export let className: string = `orbit-icon fa plane-${planeid}`;
  export let center: boolean = false;

  const handleHover = () => {
    $planeStore = plane;
  };

  const handleClick = () => {
    $planeStore = null;
    push(`/${plane.id}`);
  }

  const handleMouseout = () => {
    $planeStore = null;
  }

  let display = plane.locked ? "L" : plane.name.substring(0, 1).toUpperCase();
</script>

<li
  class={className}
  on:mouseover={handleHover}
  on:mouseout={handleMouseout}
  on:click={handleClick}
>
  {#if center}
    <i class="fa fa-home" />
  {:else if plane.locked}
    <i class="fa fa-lock" />
  {:else}{display}{/if}
</li>
