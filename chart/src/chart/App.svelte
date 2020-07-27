<script lang="ts">
  import { fade } from 'svelte/transition';

  import { rings } from './data';
  import { beginConnection } from './signalr';
  import type { Plane } from '../types';

  import Orbit from './Orbit.svelte';

  beginConnection();

  let descriptionText: string;
  let view: 'orbit' | 'description';
  let currentPlane: Partial<Plane>;

  $: descriptionText = '';
  $: view = 'orbit';
  $: currentPlane = {};

  const handleHover = (event) => {
    if (!event.detail.plane) {
      descriptionText = '';
    } else if (event.detail.plane && event.detail.plane.locked) {
      descriptionText = 'Locked';
    } else {
      descriptionText = event.detail.plane.description;
    }
  };

  const changeView = (event) => {
    currentPlane = event.detail.plane;
    view = 'description';
  };

  const resetView = () => {
    view = 'orbit';
    currentPlane = {};
    descriptionText = '';
  };
</script>

<style type="text/scss">
  // #connected-box {
  //   background-color:rgba(255, 255, 255, 0.7);
  //   padding: 4px;
  //   position: absolute;
  //   right: 24px;
  //   top: 24px;

  //   &.success {
  //     color: green;
  //   }
  // }

  #description-container {
    background-color: #ececec;
    border-radius: 4px;
    bottom: 50px;
    box-shadow: 0 0 10px rgba(255, 255, 255, 0.5);
    font-family: apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Fira Sans', 'Droid Sans', 'Helvetica Neue', sans-serif;
    height: 200px;
    padding: 12px;
    position: absolute;
    right: 50px;
    width: 400px;
  }

  .large-description-container {
    align-items: center;
    display: flex;
    height: 100vh;
    justify-content: center;
    width: 100vw;
  }

  .large-description {
    background-color: #ececec;
    border-radius: 4px;
    box-shadow: 0 0 10px rgba(255, 255, 255, 0.5);
    font-family: apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Fira Sans', 'Droid Sans', 'Helvetica Neue', sans-serif;
    height: 60vh;
    padding: 24px;
    position: absolute;
    width: 40vw;
  }
</style>

<main class="orbit">
  <!-- {#await connection}
    <div id="connected-box">
      <i class="fa fa-spinner"></i>
    </div>
  {:then _}
    <div id="connected-box" class="success">
      <i class="fa fa-link"></i>
      <button type="button" on:click={() => ping(2)}>
        ping
      </button>
    </div>
  {/await} -->
  {#if view === 'orbit'}
    <span transition:fade>
      <Orbit {rings} on:message={handleHover} on:click={changeView} />

      {#if descriptionText}
        <div id="description-container" transition:fade>
          {descriptionText}
        </div>
      {/if}
    </span>
  {:else}
    <div class="large-description-container">
      <div class="large-description" transition:fade>
        {#if currentPlane.locked}
          <i class="fa fa-lock"></i>
        {:else}
          <h2>{currentPlane.name}</h2>
          <p>{currentPlane.description}</p>
        {/if}
        <p>
          <button on:click={resetView}>Close</button>
        </p>
      </div>
    </div>
  {/if}
</main>
