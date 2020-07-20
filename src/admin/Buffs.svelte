<script>
  export let params = {};

  const loadBuffs = async (id) => {
    const res = await fetch(`/api/buffs/${id}`);
    const json = await res.json();

    if (res.ok) {
      return json;
    } else {
      throw new Error(`Could not fetch buffs for plane with id ${id}`);
    }
  };

  $: plane = "loading";

  $: if (params.id) {
    loadBuffs(params.id).then((b) => (plane = b));
  } else {
    plane = {};
  }

  $: newBuff = "";

  const addBuff = () => {
    plane.buffs = [
      ...plane.buffs,
      {
        name: newBuff,
        locked: true,
        revealed: false,
      },
    ];

    newBuff = "";
  };

  const removeBuff = name => {
    plane.buffs = plane.buffs.filter(x => x.name !== name);
  }

  $: disabled = false;

  const saveBuffs = async () => {
    disabled = true;

    const url = `/api/buffs/${plane.id}`;

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

{#if plane === 'loading'}
  <div class="spinner-border text-danger" role="status">
    <span class="sr-only">Loading...</span>
  </div>
{:else}
  <h2>Buffs for {plane.name}</h2>

  <div class="row">
    <div class="col-6">
      <label class="form-label">Buffs</label>
      {#each plane.buffs as buff}
        <div class="row">
          <div class="col">
            <input type="text" class="form-control" bind:value={buff.name} />
          </div>
          <div class="col-1">
            <button type="button" class="btn btn-link" on:click={removeBuff(buff.name)}>
              <i class="fa fa-trash text-danger" />
            </button>
          </div>
        </div>
      {/each}
      <hr />
      <label class="form-label">Add new</label>
      <div class="row">
        <div class="col">
          <input type="text" class="form-control" bind:value={newBuff} />
        </div>
        <div class="col-1">
          <button type="button" class="btn btn-link" on:click={addBuff}>
            <i class="fa fa-plus text-success" />
          </button>
        </div>
      </div>
      <hr />
    </div>
  </div>

  <button type="button" class="btn btn-primary" on:click={saveBuffs} {disabled}>
    {#if disabled}
      <span
        class="spinner-border spinner-border-sm"
        role="status"
        aria-hidden="true" />
    {/if}
    Save
  </button>
{/if}
