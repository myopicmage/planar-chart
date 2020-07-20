<script>
  export let plane = {};
</script>

<form>
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
      <label class="form-label">Status</label><br />
      <div class="form-check form-check-inline form-switch">
        <input type="checkbox" class="form-check-input" bind:checked={plane.revealed} />
        <label class="form-check-label">Revealed</label>
      </div>
      <div class="form-check form-check-inline form-switch">
        <input type="checkbox" class="form-check-input" bind:checked={plane.locked} />
        <label class="form-check-label">Locked</label>
      </div>
    </div>
  </div>
  <div class="row mt-3">
    <div class="col-6">
      <label class="form-label">Description</label>
      <textarea class="form-control" bind:value={plane.description}></textarea>
    </div>
  </div>
  <div class="row mt-3">
    <div class="col-2">
      <button class="btn btn-primary">Save or whatever</button>
    </div>
  </div>
</form>
