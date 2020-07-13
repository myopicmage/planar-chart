<script>
    export let plane;
    export let className = 'orbit-icon fa';

    import { createEventDispatcher } from 'svelte';

    const dispatch = createEventDispatcher();

    const handleHover = () => {
        dispatch('message', {
            text: plane.description
        });
    };
</script>

<li 
    class={className} 
    on:mouseover={handleHover} 
    on:mouseout={() => dispatch('message', { text: ''})}
    on:click={() => dispatch('click', { plane })}
>
    {plane.name.substring(0, 1).toUpperCase()}
</li>