<script>
    export let plane;
    export let planeid;
    export let className = `orbit-icon fa plane-${planeid}`;

    import { createEventDispatcher } from 'svelte';

    const dispatch = createEventDispatcher();

    const handleHover = () => {
        dispatch('message', {
            plane
        });
    };

    let display = plane.locked
        ? "L"
        : plane.name.substring(0, 1).toUpperCase();
</script>

<li 
    class={className} 
    on:mouseover={handleHover} 
    on:mouseout={() => dispatch('message', { })}
    on:click={() => dispatch('click', { plane })}
>
    {#if plane.locked}
    <i class="fa fa-lock"></i>
    {:else}
    {display}
    {/if}
</li>