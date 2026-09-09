import React, { useState, useMemo } from 'react';
import { Search, ChevronLeft, ChevronRight, ArrowUpDown, Download, Filter } from 'lucide-react';

export interface Column<T> {
  key: string;
  header: string;
  render?: (item: T) => React.ReactNode;
  sortable?: boolean;
  width?: string;
}

interface ModernDataGridProps<T> {
  id?: string;
  data: T[];
  columns: Column<T>[];
  searchPlaceholder?: string;
  searchFields?: (keyof T)[];
  onRowClick?: (item: T) => void;
  actions?: React.ReactNode;
  exportFileName?: string;
  pageSize?: number;
}

export function ModernDataGrid<T extends { id: number | string }>({
  id = 'modern-grid',
  data = [],
  columns,
  searchPlaceholder = 'بحث سريع في البيانات...',
  searchFields = [],
  onRowClick,
  actions,
  exportFileName = 'export-data',
  pageSize = 8
}: ModernDataGridProps<T>) {
  const [searchTerm, setSearchTerm] = useState('');
  const [sortColumn, setSortColumn] = useState<string | null>(null);
  const [sortDirection, setSortDirection] = useState<'asc' | 'desc'>('asc');
  const [currentPage, setCurrentPage] = useState(1);
  const [selectedRowId, setSelectedRowId] = useState<number | string | null>(null);

  // Filtering
  const filteredData = useMemo(() => {
    const safeData = data || [];
    if (!searchTerm.trim()) return safeData;
    const term = searchTerm.toLowerCase().trim();
    return safeData.filter((item) => {
      if (searchFields.length > 0) {
        return searchFields.some((field) => {
          const val = item[field];
          return val !== undefined && val !== null && String(val).toLowerCase().includes(term);
        });
      }
      return Object.values(item).some((val) =>
        val !== undefined && val !== null && String(val).toLowerCase().includes(term)
      );
    });
  }, [data, searchTerm, searchFields]);

  // Sorting
  const sortedData = useMemo(() => {
    const safeFiltered = filteredData || [];
    if (!sortColumn) return safeFiltered;
    return [...safeFiltered].sort((a: any, b: any) => {
      const valA = a[sortColumn];
      const valB = b[sortColumn];
      if (valA === valB) return 0;
      if (valA === null || valA === undefined) return 1;
      if (valB === null || valB === undefined) return -1;
      const comparison = valA > valB ? 1 : -1;
      return sortDirection === 'asc' ? comparison : -comparison;
    });
  }, [filteredData, sortColumn, sortDirection]);

  // Pagination
  const totalPages = Math.max(1, Math.ceil((sortedData || []).length / pageSize));
  const paginatedData = useMemo(() => {
    const start = (currentPage - 1) * pageSize;
    return (sortedData || []).slice(start, start + pageSize);
  }, [sortedData, currentPage, pageSize]);

  const handleSort = (key: string) => {
    if (sortColumn === key) {
      setSortDirection((prev) => (prev === 'asc' ? 'desc' : 'asc'));
    } else {
      setSortColumn(key);
      setSortDirection('asc');
    }
  };

  const exportToCsv = () => {
    if (data.length === 0) return;
    const headers = columns.map((c) => c.header).join(',');
    const rows = data.map((item: any) =>
      columns
        .map((c) => {
          const val = item[c.key];
          return `"${String(val ?? '').replace(/"/g, '""')}"`;
        })
        .join(',')
    );
    const csvContent = 'data:text/csv;charset=utf-8,\uFEFF' + [headers, ...rows].join('\n');
    const encodedUri = encodeURI(csvContent);
    const link = document.createElement('a');
    link.setAttribute('href', encodedUri);
    link.setAttribute('download', `${exportFileName}.csv`);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  };

  return (
    <div id={id} className="bg-slate-900 border border-slate-800 rounded-xl overflow-hidden shadow-xl flex flex-col">
      {/* Table Header Bar */}
      <div className="p-4 border-b border-slate-800 bg-slate-900/80 flex flex-wrap items-center justify-between gap-3">
        <div className="relative min-w-[260px] flex-1 max-w-md">
          <Search className="absolute right-3 top-2.5 w-4 h-4 text-slate-400" />
          <input
            type="text"
            placeholder={searchPlaceholder}
            value={searchTerm}
            onChange={(e) => {
              setSearchTerm(e.target.value);
              setCurrentPage(1);
            }}
            className="w-full bg-slate-950/70 border border-slate-800 rounded-lg pr-9 pl-4 py-2 text-sm text-slate-100 placeholder-slate-500 focus:outline-none focus:border-blue-500 transition-colors"
          />
        </div>

        <div className="flex items-center gap-2">
          {actions}
          <button
            onClick={exportToCsv}
            className="flex items-center gap-1.5 px-3 py-2 bg-slate-800 hover:bg-slate-700 text-slate-200 text-xs font-semibold rounded-lg border border-slate-700 transition-colors cursor-pointer"
            title="تصدير إلى ملف Excel (CSV)"
          >
            <Download className="w-3.5 h-3.5 text-blue-400" />
            <span>تصدير Excel</span>
          </button>
        </div>
      </div>

      {/* Table Container */}
      <div className="overflow-x-auto">
        <table className="w-full text-right border-collapse text-sm">
          <thead>
            <tr className="bg-slate-950/60 border-b border-slate-800 text-slate-400 text-xs font-medium uppercase tracking-wider">
              <th className="py-3 px-4 w-12 text-center">#</th>
              {columns.map((col) => (
                <th
                  key={col.key}
                  style={{ width: col.width }}
                  className={`py-3 px-4 font-semibold ${col.sortable ? 'cursor-pointer select-none hover:text-blue-400' : ''}`}
                  onClick={() => col.sortable && handleSort(col.key)}
                >
                  <div className="flex items-center gap-1.5">
                    <span>{col.header}</span>
                    {col.sortable && (
                      <ArrowUpDown
                        className={`w-3.5 h-3.5 ${
                          sortColumn === col.key ? 'text-blue-400' : 'text-slate-600'
                        }`}
                      />
                    )}
                  </div>
                </th>
              ))}
            </tr>
          </thead>
          <tbody className="divide-y divide-slate-800/60 font-normal">
            {paginatedData.length > 0 ? (
              paginatedData.map((item, index) => {
                const isSelected = selectedRowId === item.id;
                const rowNum = (currentPage - 1) * pageSize + index + 1;
                return (
                  <tr
                    key={item.id}
                    onClick={() => {
                      setSelectedRowId(item.id);
                      onRowClick?.(item);
                    }}
                    className={`transition-colors cursor-pointer ${
                      isSelected
                        ? 'bg-blue-900/30 text-blue-100 font-medium'
                        : index % 2 === 0
                        ? 'bg-slate-900/40 hover:bg-slate-800/60'
                        : 'bg-slate-950/30 hover:bg-slate-800/60'
                    }`}
                  >
                    <td className="py-3 px-4 text-xs text-center text-slate-500 font-mono">
                      {rowNum}
                    </td>
                    {columns.map((col) => (
                      <td key={col.key} className="py-3 px-4 text-slate-200">
                        {col.render ? col.render(item) : String((item as any)[col.key] ?? '—')}
                      </td>
                    ))}
                  </tr>
                );
              })
            ) : (
              <tr>
                <td colSpan={columns.length + 1} className="py-12 text-center text-slate-500">
                  <Filter className="w-8 h-8 mx-auto mb-2 text-slate-600 opacity-60" />
                  <p className="text-base font-semibold text-slate-400">لا توجد بيانات مطابقة للبحث</p>
                  <p className="text-xs text-slate-600 mt-1">تأكد من كتابة الكلمات بشكل صحيح أو امسح حقل البحث</p>
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      {/* Pagination Footer */}
      <div className="p-3 bg-slate-950/60 border-t border-slate-800 flex flex-wrap items-center justify-between gap-3 text-xs text-slate-400">
        <div className="flex items-center gap-2">
          <span>إجمالي السجلات:</span>
          <span className="font-semibold text-slate-200">{filteredData.length}</span>
          {filteredData.length !== data.length && (
            <span className="text-slate-500">(من أصل {data.length})</span>
          )}
        </div>

        <div className="flex items-center gap-1.5">
          <button
            onClick={() => setCurrentPage((p) => Math.max(1, p - 1))}
            disabled={currentPage === 1}
            className="p-1.5 rounded-md bg-slate-800 hover:bg-slate-700 disabled:opacity-40 disabled:cursor-not-allowed text-slate-300 transition-colors"
            title="الصفحة السابقة"
          >
            <ChevronRight className="w-4 h-4" />
          </button>

          <span className="px-3 py-1 bg-slate-900 border border-slate-800 rounded-md font-mono text-slate-200">
            {currentPage} / {totalPages}
          </span>

          <button
            onClick={() => setCurrentPage((p) => Math.min(totalPages, p + 1))}
            disabled={currentPage === totalPages}
            className="p-1.5 rounded-md bg-slate-800 hover:bg-slate-700 disabled:opacity-40 disabled:cursor-not-allowed text-slate-300 transition-colors"
            title="الصفحة التالية"
          >
            <ChevronLeft className="w-4 h-4" />
          </button>
        </div>
      </div>
    </div>
  );
}
