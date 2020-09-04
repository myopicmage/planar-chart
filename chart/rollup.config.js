import svelte from 'rollup-plugin-svelte';
import resolve from '@rollup/plugin-node-resolve';
import commonjs from '@rollup/plugin-commonjs';
import livereload from 'rollup-plugin-livereload';
import preprocess from 'svelte-preprocess';
import typescript from '@rollup/plugin-typescript';
import { terser } from 'rollup-plugin-terser';

const production = !process.env.ROLLUP_WATCH;

const inputs = [
	{
		path: './src/chart/chart.ts',
		name: 'chart'
	},
	{
		path: './src/admin/admin.ts',
		name: 'admin'
	}
];

const makeConfig = ({ path, name }) => ({
	input: path,
	output: {
		sourcemap: true,
		format: 'iife',
		name: name,
		file: `wwwroot/build/${name}.js`
	},
	plugins: [
		svelte({
			// enable run-time checks when not in production
			dev: !production,
			// we'll extract any component CSS out into
			// a separate file - better for performance
			css: css => {
				css.write(`${name}.css`);
			},
			preprocess: preprocess()
		}),
    typescript({ sourceMap: !production }),

		// If you have external dependencies installed from
		// npm, you'll most likely need these plugins. In
		// some cases you'll need additional configuration -
		// consult the documentation for details:
		// https://github.com/rollup/plugins/tree/master/packages/commonjs
		resolve({
			browser: true,
			dedupe: ['svelte']
		}),
    commonjs(),

		// Watch the `public` directory and refresh the
		// browser on changes when not in production
		!production && livereload('wwwroot'),

		// If we're building for production (npm run build
		// instead of npm run dev), minify
		production && terser()
	],
	watch: {
		clearScreen: false
	}
});

export default inputs.map(makeConfig);