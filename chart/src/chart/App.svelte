<script lang="ts">
  import { fade } from 'svelte/transition';
  import Router from "svelte-spa-router";
  import { planeStore } from "./planestore";

  import { beginConnection } from "./signalr";

  import Orbit from "./Orbit.svelte";
  import Description from "./Description.svelte";

  const routes = {
    "/:id": Description,
    "/": Orbit,
  };

  beginConnection();
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

    h4 {
      margin-top: 0;
    }
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
  <Router {routes} />

  {#if $planeStore}
    <div id="description-container" transition:fade>
      <h4>
        {#if $planeStore.locked}
          <i class="fa fa-lock"></i>
        {:else}
          {$planeStore.name}
        {/if}
      </h4>
      {$planeStore.locked ? 'Locked' : $planeStore.description}
    </div>
  {/if}
</main>
