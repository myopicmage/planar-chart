<script lang="ts">
  import { fade } from "svelte/transition";
  import { push } from 'svelte-spa-router';
  import { rings } from './data';
  import type { Plane } from "../types";

  type DescriptionParams = {
    id?: string;
  };

  export let params: DescriptionParams = {};

  let currentPlane: Partial<Plane>;
  let title: string = 'Planar Chart';

  if (params.id) {
    const ringId = parseInt(params.id, 10);
    currentPlane = $rings.flatMap(x => x.planes).find(x => x.id === ringId);

    title = `Planar Chart - ${currentPlane.locked ? 'Locked' : currentPlane.name}`;
  }

  $: document.title = title;

  const resetView = () => push('/');
</script>

<style type="text/scss">
  .large-description-container {
    align-items: center;
    display: flex;
    height: 100vh;
    justify-content: center;
    width: 100vw;

    .large-description {
      background-color: #ececec;
      border-radius: 4px;
      box-shadow: 0 0 10px rgba(255, 255, 255, 0.5);
      font-family: apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
        Ubuntu, Cantarell, "Fira Sans", "Droid Sans", "Helvetica Neue",
        sans-serif;
      height: 60vh;
      padding: 24px;
      position: absolute;
      width: 40vw;
    }
  }
</style>

<div class="large-description-container">
  <div class="large-description" transition:fade>
    {#if currentPlane.locked}
      <i class="fa fa-lock" />
    {:else}
      <h2>{currentPlane.name}</h2>
      <p>{currentPlane.description}</p>
    {/if}
    <p>
      <button on:click={resetView}>Close</button>
    </p>
  </div>
</div>
