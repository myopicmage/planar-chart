<script lang="ts">
  import Plane from "./Plane.svelte";
  import { rings } from './data';

  const [center, ...rest] = $rings;
</script>

<ul class="orbit-wrap">

  <Plane plane={center} className="orbit-center" center={true} />

  {#each rest as ring, i}
    <li>
      <ul class="ring-{i}">
        {#each ring.planes as plane, planeid (plane.id)}
          <Plane {plane} {planeid} />
        {/each}
      </ul>
    </li>
  {/each}

</ul>
