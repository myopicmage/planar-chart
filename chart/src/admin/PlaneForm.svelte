<script lang="ts">
  import { push } from 'svelte-spa-router';
  import type { Plane } from '../types';

  export let plane: Partial<Plane> = {};

  $: disabled = false;
  $: newBuff = '';

  const addBuff = () => {
    plane.buffs = [
      ...plane.buffs,
      {
        id: 0,
        name: newBuff,
        locked: true,
        revealed: false,
      },
    ];

    newBuff = "";
  };

  const removeBuff = (name: string) => {
    plane.buffs = plane.buffs.filter(x => x.name !== name);
  }

  const handleSubmit = async () => {
    disabled = true;

    const url = plane.id ? `/api/plane/${plane.id}` : "/api/plane/add";

    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(plane),
    }).then((resp) => {
      if (resp.ok) {
        push('/');
      }
    }).finally(() => (disabled = false));
  };
</script>

<style>
  .description {
    min-height: 300px;
  }
</style>

<form on:submit|preventDefault={handleSubmit}>
  <div class="row">
    <div class="col-2">
      <label class="form-label" for="ring">Ring</label>
      <select class="form-select" bind:value={plane.ring} name="ring">
        <option value={0}>Center</option>
        <option value={1}>Echoes</option>
        <option value={2}>Chaos</option>
        <option value={3}>Wild Reaches</option>
      </select>
    </div>
    <div class="col-4">
      <label class="form-label" for="plane-name">Name</label>
      <input bind:value={plane.name} class="form-control" name="plane-name" />
    </div>
    <div class="col-6">
      <label class="form-label" for="status">Status</label>
      <br />
      <div class="form-check form-check-inline form-switch">
        <input
          type="checkbox"
          name="revealed"
          class="form-check-input"
          bind:checked={plane.revealed} />
        <label class="form-check-label" for="revealed">Revealed</label>
      </div>
      <div class="form-check form-check-inline form-switch">
        <input
          type="checkbox"
          name="locked"
          class="form-check-input"
          bind:checked={plane.locked} />
        <label class="form-check-label" for="locked">Locked</label>
      </div>
    </div>
  </div>
  <div class="row mt-3">
    <div class="col-6">
      <label class="form-label" for="description">Description</label>
      <textarea
        name="description"
        class="form-control description"
        bind:value={plane.description} />
    </div>
    <div class="col">
      <label class="form-label" for="buffs">Buffs</label>
      {#each plane.buffs as buff}
        <div class="row">
          <div class="col">
            <input type="text" class="form-control" bind:value={buff.name} />
          </div>
          <div class="col-1">
            <button type="button" class="btn btn-link" on:click={() => removeBuff(buff.name)}>
              <i class="fa fa-trash text-danger" />
            </button>
          </div>
        </div>
      {/each}
      <hr />
      <label class="form-label" for="new-buff">Add new</label>
      <div class="row">
        <div class="col">
          <input type="text" class="form-control" bind:value={newBuff} name="new-buff" />
        </div>
        <div class="col-1">
          <button type="button" class="btn btn-link" on:click={addBuff}>
            <i class="fa fa-plus text-success" />
          </button>
        </div>
      </div>
    </div>
  </div>
  <div class="row mt-3">
    <div class="col-2">
      <button class="btn btn-primary" {disabled}>
        {#if disabled}
          <span
            class="spinner-border spinner-border-sm"
            role="status"
            aria-hidden="true" />
        {/if}
        Save
      </button>
    </div>
  </div>
</form>
