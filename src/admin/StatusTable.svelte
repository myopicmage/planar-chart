<script>
  import marked from 'marked';

  const loadTable = async () => {
    const res = await fetch("/api/plane");
    const text = res.json();

    if (res.ok) {
      return text;
    } else {
      throw new Error("Could not load data");
    }
  };

  let loading = loadTable();
</script>

{#await loading}
  <div class="spinner-border text-danger" role="status">
    <span class="sr-only">Loading...</span>
  </div>
{:then data}
  <table class="table">
    <thead>
      <tr>
        <th>Ring</th>
        <th>Name</th>
        <th>Description</th>
        <th>Buffs</th>
        <th>Locations</th>
        <th>Locked</th>
        <th>Revealed</th>
      </tr>
    </thead>
    <tbody>
      {#each data as plane (plane.id)}
        <tr>
          <td>{plane.ring}</td>
          <td>
            <a href={`#/planes/${plane.id}`}>
              {plane.name}
            </a>
          </td>
          <td>{@html marked(plane.description)}</td>
          <td>
            <ul>
              {#each plane.buffs as buff}
                <li>{buff.name}</li>
              {/each}
            </ul>
          </td>
          <td>{plane.locations}</td>
          <td>
            {#if plane.locked}
              <i class="fa fa-lock text-danger" />
            {:else}
              <i class="fa fa-unlock text-success" />
            {/if}
          </td>
          <td>
            {#if plane.revealed}
              <i class="fa fa-check text-success" />
            {:else}
              <i class="fa fa-lock text-danger" />
            {/if}
          </td>
        </tr>
      {/each}
    </tbody>
  </table>
{:catch err}
  {err}
{/await}
