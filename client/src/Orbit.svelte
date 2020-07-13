<script>
    import Plane from './Plane.svelte';

    export let rings;

    const [center, ...rest] = rings;
</script>

<ul class="orbit-wrap">

  <Plane plane={center} className="orbit-center" />

  {#each rest as ring, i}
    <li>
      <ul class="ring-{i}">
        {#each ring.planes as plane (plane.name)}
          <Plane plane={plane} on:message on:click />
        {/each}
      </ul>
    </li>
  {/each}

</ul>
