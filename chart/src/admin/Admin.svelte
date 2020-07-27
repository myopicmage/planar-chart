<script>
  import StatusTable from './StatusTable.svelte';
  import Plane from './Plane.svelte';

  import Router from 'svelte-spa-router';

  const routes = {
    '/planes/:id?': Plane,
    '/': StatusTable,
  };
</script>

<nav class="navbar navbar-expand-lg navbar-dark bg-dark">

  <div class="container">
    <a class="navbar-brand" href="/admin">Planar Chart Admin</a>
    <ul class="navbar-nav mr-auto mb-2 mb-lg-0">
      <li class="nav-item">
        <a class="nav-link active" aria-current="page" href="/admin">Admin</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#/planes">Planes</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="/admin">Locations</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="/admin">Quests</a>
      </li>
    </ul>
  </div>
</nav>

<div class="container mt-3">
  <div class="row">
    <div class="col">
      <Router {routes} />
    </div>
  </div>
</div>
