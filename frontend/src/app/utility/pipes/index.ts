import {SafeHtmlPipe} from "./safe-html.pipe";
import {PipeSeparatorPipe} from "./pipe-separator.pipe";
import {TruncatePipe} from "./truncate.pipe";


export const pipes: any[] = [
  SafeHtmlPipe,
  PipeSeparatorPipe,
  TruncatePipe,
];

export * from './safe-html.pipe';
export * from './pipe-separator.pipe';
export * from './truncate.pipe';
