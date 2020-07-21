<script>
  import PlaneForm from './PlaneForm.svelte';

  export let params = {};

  const loadPlane = async (id) => {
    const res = await fetch(`/api/plane/${id}`);
    const json = await res.json();

    if (res.ok) {
      return json;
    } else {
      throw new Error(`Could not fetch plane with id ${id}`);
    }
  }

  $: plane = 'loading';

  $: if (params.id) {
    loadPlane(params.id).then(p => plane = p);
  } else {
    plane = {};
  }
</script>

{#if plane === 'loading'}
  <div class="spinner-border text-danger" role="status">
    <span class="sr-only">Loading...</span>
  </div>
{:else}
  <PlaneForm {plane} />
{/if}