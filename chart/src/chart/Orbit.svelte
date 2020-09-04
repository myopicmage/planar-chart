<script lang="ts">
  import Plane from "./Plane.svelte";
  import { apiPlanes, loadPlanes } from './data';

  document.title = 'Planar Chart';

  loadPlanes().then(x => $apiPlanes = x);

  const center = {
    locked: false,
    name: 'Prime Material Plane'
  };
</script>

<ul class="orbit-wrap">

  <Plane plane={center} className="orbit-center" center={true} />

  {#each $apiPlanes as ring, i}
    <li>
      <ul class="ring-{i}">
        {#each ring as plane, planeid (plane.id)}
          <Plane {plane} {planeid} />
        {/each}
      </ul>
    </li>
  {/each}

</ul>
