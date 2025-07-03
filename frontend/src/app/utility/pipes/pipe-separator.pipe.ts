import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'pipeSeparator'
})
export class PipeSeparatorPipe implements PipeTransform {
  transform(value: any[]): string {
    if (!Array.isArray(value)) return '';

    return value.map((item, index) =>
      index < value.length - 1 ? `${item} |` : `${item}`
    ).join(' ');
  }
}
