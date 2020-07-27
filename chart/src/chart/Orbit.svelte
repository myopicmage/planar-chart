<script lang="ts">
  import Plane from "./Plane.svelte";
  import type { Ring } from "./data";

  export let rings: Ring[];

  const [center, ...rest] = rings;
</script>

<ul class="orbit-wrap">

  <Plane plane={center} className="orbit-center" center={true} />

  {#each rest as ring, i}
    <li>
      <ul class="ring-{i}">
        {#each ring.planes as plane, planeid (plane.id)}
          <Plane on:message on:click {plane} {planeid} />
        {/each}
      </ul>
    </li>
  {/each}

</ul>
