<script>
  export let plane = {};

  $: disabled = false;

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
        console.log("it worked");
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
      <label class="form-label">Ring</label>
      <select class="form-select" bind:value={plane.ring}>
        <option value={0}>Center</option>
        <option value={1}>Echoes</option>
        <option value={2}>Chaos</option>
        <option value={3}>Wild Reaches</option>
      </select>
    </div>
    <div class="col-4">
      <label class="form-label">Name</label>
      <input bind:value={plane.name} class="form-control" />
    </div>
    <div class="col-6">
      <label class="form-label">Status</label>
      <br />
      <div class="form-check form-check-inline form-switch">
        <input
          type="checkbox"
          class="form-check-input"
          bind:checked={plane.revealed} />
        <label class="form-check-label">Revealed</label>
      </div>
      <div class="form-check form-check-inline form-switch">
        <input
          type="checkbox"
          class="form-check-input"
          bind:checked={plane.locked} />
        <label class="form-check-label">Locked</label>
      </div>
    </div>
  </div>
  <div class="row mt-3">
    <div class="col-6">
      <label class="form-label">Description</label>
      <textarea
        class="form-control description"
        bind:value={plane.description} />
    </div>
    <div class="col">
      <label class="form-label">Buffs</label>
      {#if plane.buffs && plane.buffs.length}
        <ul>
          {#each plane.buffs as buff}
            <li>{buff.name}</li>
          {/each}
        </ul>
      {:else}
        <p>No buffs</p>
      {/if}
      {#if plane.id}
        <a href={`#/buffs/${plane.id}`}>
          <i class="fa fa-edit"></i> Modify
        </a>
      {/if}
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
